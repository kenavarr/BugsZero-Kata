﻿using System;
using System.Collections.Generic;
using System.Linq;
using Trivia.Domain.Players;
using Trivia.Domain.Players.Events;
using Trivia.Domain.Status;
using Trivia.Domain.Status.Events;

namespace Trivia
{
	public class Game : IDisposable
	{
		List<PlayerStatus> playersStatus = new List<PlayerStatus>();

		int[] places = new int[6];
		int[] purses = new int[6];

		LinkedList<string> popQuestions = new LinkedList<string>();
		LinkedList<string> scienceQuestions = new LinkedList<string>();
		LinkedList<string> sportsQuestions = new LinkedList<string>();
		LinkedList<string> rockQuestions = new LinkedList<string>();

		int currentPlayer = -1;
		string currentPlayerName;

		public Game()
		{
			PlayerEvents.OnPlayerTriggered += OnPlayerTriggered;
			PlayerStatusEvents.OnPlayerStatusTriggered += OnPlayerStatusTriggered;

			for (int i = 0; i < 50; i++)
			{
				popQuestions.AddLast("Pop Question " + i);
				scienceQuestions.AddLast(("Science Question " + i));
				sportsQuestions.AddLast(("Sports Question " + i));
				rockQuestions.AddLast(CreateRockQuestion(i));
			}
		}

		public String CreateRockQuestion(int index)
		{
			return "Rock Question " + index;
		}

		public bool IsPlayable()
		{
			return (HowManyPlayers() >= 2);
		}

		public void AddPlayer(String playerName)
		{
			PlayerAggregate.Create(playerName);
		}

		public void Roll(int roll)
		{
			Console.WriteLine(playersStatus[currentPlayer].Player.Name + " is the current player");
			Console.WriteLine("They have rolled a " + roll);

			if (playersStatus[currentPlayer].IsPrisoner)
			{
				if (roll % 2 != 0)
				{
					playersStatus[currentPlayer].Release();

					Console.WriteLine(playersStatus[currentPlayer].Player.Name + " is getting out of the penalty box");
					places[currentPlayer] = places[currentPlayer] + roll;
					if (places[currentPlayer] > 11) places[currentPlayer] = places[currentPlayer] - 12;

					Console.WriteLine(playersStatus[currentPlayer].Player.Name
							+ "'s new location is "
							+ places[currentPlayer]);
					Console.WriteLine("The category is " + CurrentCategory());
					AskQuestion();
				}
				else
				{
					Console.WriteLine(playersStatus[currentPlayer].Player.Name + " is not getting out of the penalty box");
				}

			}
			else
			{

				places[currentPlayer] = places[currentPlayer] + roll;
				if (places[currentPlayer] > 11) places[currentPlayer] = places[currentPlayer] - 12;

				Console.WriteLine(playersStatus[currentPlayer].Player.Name
						+ "'s new location is "
						+ places[currentPlayer]);
				Console.WriteLine("The category is " + CurrentCategory());
				AskQuestion();
			}

		}

		public void Answer(int diceScore)
		{
			playersStatus[currentPlayer].Player.Answer(diceScore);
		}

		public bool DidPlayerWin()
		{
			return !(purses[currentPlayer] == 6);
		}

		public PlayerStatus GetCurrentPlayerStatus()
		{
			return playersStatus.Single(ps => ps.Player.Name == currentPlayerName);
		}

		public void SwitchToNextPlayer()
		{
			currentPlayer++;
			if (currentPlayer == playersStatus.Count) currentPlayer = 0;
			currentPlayerName = playersStatus[currentPlayer].Player.Name;
		}

		private void AskQuestion()
		{
			if (CurrentCategory() == "Pop")
			{
				Console.WriteLine(popQuestions.First());
				popQuestions.RemoveFirst();
			}
			if (CurrentCategory() == "Science")
			{
				Console.WriteLine(scienceQuestions.First());
				scienceQuestions.RemoveFirst();
			}
			if (CurrentCategory() == "Sports")
			{
				Console.WriteLine(sportsQuestions.First());
				sportsQuestions.RemoveFirst();
			}
			if (CurrentCategory() == "Rock")
			{
				Console.WriteLine(rockQuestions.First());
				rockQuestions.RemoveFirst();
			}
		}

		private String CurrentCategory()
		{
			if (places[currentPlayer] == 0) return "Pop";
			if (places[currentPlayer] == 4) return "Pop";
			if (places[currentPlayer] == 8) return "Pop";
			if (places[currentPlayer] == 1) return "Science";
			if (places[currentPlayer] == 5) return "Science";
			if (places[currentPlayer] == 9) return "Science";
			if (places[currentPlayer] == 2) return "Sports";
			if (places[currentPlayer] == 6) return "Sports";
			if (places[currentPlayer] == 10) return "Sports";
			return "Rock";
		}

		private void OnPlayerTriggered(IPlayerEvent playerEvent)
		{
			switch (playerEvent)
			{
				case PlayerAddedEvent playerAdded:
					PlayerStatusAggregate.Init(playerAdded.Player);
					return;
				case PlayerAnswerdCorrectlyEvent playerAnswerdCorrectly:
					WasCorrectlyAnswered(playerAnswerdCorrectly.Player);
					return;
				case PlayerAnswerdBadlyEvent playerAnswerdBadly:
					WrongAnswer(playerAnswerdBadly.Player);
					return;
			}
		}

		private void WasCorrectlyAnswered(Player player)
		{
			PlayerStatus playerStatus = playersStatus.Single(ps => ps.Player.Name == player.Name);

			if (!playerStatus.IsPrisoner)
			{

				Console.WriteLine("Answer was correct!!!!");
				purses[currentPlayer]++;
				playerStatus.IncreaseScore();
				Console.WriteLine(playersStatus[currentPlayer].Player.Name
						+ " now has "
						+ purses[currentPlayer]
						+ " Gold Coins.");
			}
		}

		private void WrongAnswer(Player player)
		{
			Console.WriteLine("Question was incorrectly answered");
			playersStatus.Single(ps => ps.Player.Name == player.Name).Imprison();
			Console.WriteLine(playersStatus[currentPlayer].Player.Name + " was sent to the penalty box");
		}

		private void OnPlayerStatusTriggered(IPlayerStatusEvent playerStatusEvent)
		{
			switch (playerStatusEvent)
			{
				case PlayerStatusCreatedEvent playerStatusCreated:
					AddPlayerStatus(playerStatusCreated.PlayerStatus);
					return;
				case PlayerStatusImprisonnedEvent playerStatusImprisonned:
				case PlayerStatusReleasedEvent playerStatusReleased:
				case PlayerStatusIncreasedScoreEvent playerStatusIncreasedScore:
					ChangePlayerStatus(playerStatusEvent.PlayerStatus);
					return;
			}
		}

		private void AddPlayerStatus(PlayerStatus playerStatus)
		{
			playersStatus.Add(playerStatus);

			places[HowManyPlayers()] = 0;
			purses[HowManyPlayers()] = 0;

			Console.WriteLine(playerStatus.Player.Name + " was Added");
			Console.WriteLine("They are player number " + playersStatus.Count);
		}

		private int HowManyPlayers()
		{
			return playersStatus.Count;
		}

		private void ChangePlayerStatus(PlayerStatus newplayerStatus)
		{
			var oldPlayerStatus = playersStatus.Single(ps => ps.Player.Name == newplayerStatus.Player.Name);
			playersStatus.Remove(oldPlayerStatus);
			playersStatus.Add(newplayerStatus);
		}

		public void Dispose()
		{
			PlayerEvents.OnPlayerTriggered -= OnPlayerTriggered;
			PlayerStatusEvents.OnPlayerStatusTriggered -= OnPlayerStatusTriggered;
		}
	}

}
