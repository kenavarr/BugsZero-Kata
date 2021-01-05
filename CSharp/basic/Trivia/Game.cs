using System;
using System.Collections.Generic;
using System.Linq;
using Trivia.Domain.Players;
using Trivia.Domain.Status;

namespace Trivia
{
	public class Game
	{
		List<PlayerStatus> playersStatus = new List<PlayerStatus>();

		int[] places = new int[6];
		int[] purses = new int[6];

		LinkedList<string> popQuestions = new LinkedList<string>();
		LinkedList<string> scienceQuestions = new LinkedList<string>();
		LinkedList<string> sportsQuestions = new LinkedList<string>();
		LinkedList<string> rockQuestions = new LinkedList<string>();

		int currentPlayer = -1;
		bool isGettingOutOfPenaltyBox;

		public Game()
		{
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

		public bool AddPlayer(String playerName)
		{
			Player newPlayer = PlayerAggregate.Create(playerName);
			playersStatus.Add(PlayerStatusAggregate.Init(newPlayer));

			places[HowManyPlayers()] = 0;
			purses[HowManyPlayers()] = 0;

			Console.WriteLine(playerName + " was Added");
			Console.WriteLine("They are player number " + playersStatus.Count);
			return true;
		}

		public int HowManyPlayers()
		{
			return playersStatus.Count;
		}

		public void Roll(int roll)
		{
			Console.WriteLine(playersStatus[currentPlayer].Player.Name + " is the current player");
			Console.WriteLine("They have rolled a " + roll);

			if (playersStatus[currentPlayer].IsPrisoner)
			{
				if (roll % 2 != 0)
				{
					isGettingOutOfPenaltyBox = true;

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
					isGettingOutOfPenaltyBox = false;
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

		public bool Answer(int diceScore)
		{
			if (playersStatus[currentPlayer].Player.Answer(diceScore))
				return WasCorrectlyAnswered();
			else
				return WrongAnswer();
		}

		public bool WasCorrectlyAnswered()
		{
			if (playersStatus[currentPlayer].IsPrisoner)
			{
				if (isGettingOutOfPenaltyBox)
				{
					playersStatus[currentPlayer] = playersStatus[currentPlayer].Release();
					Console.WriteLine("Answer was correct!!!!");
					purses[currentPlayer]++;
					playersStatus[currentPlayer] = playersStatus[currentPlayer].IncreaseScore();
					Console.WriteLine(playersStatus[currentPlayer].Player.Name
							+ " now has "
							+ purses[currentPlayer]
							+ " Gold Coins.");

					bool winner = DidPlayerWin();

					return winner;
				}
				else
				{
					return true;
				}
			}
			else
			{
				Console.WriteLine("Answer was corrent!!!!");
				purses[currentPlayer]++;
				playersStatus[currentPlayer] = playersStatus[currentPlayer].IncreaseScore();
				Console.WriteLine(playersStatus[currentPlayer].Player.Name
						+ " now has "
						+ purses[currentPlayer]
						+ " Gold Coins.");

				bool winner = DidPlayerWin();

				return winner;
			}
		}

		public bool WrongAnswer()
		{
			Console.WriteLine("Question was incorrectly answered");
			playersStatus[currentPlayer] = playersStatus[currentPlayer].Imprison();
			Console.WriteLine(playersStatus[currentPlayer].Player.Name + " was sent to the penalty box");

			return true;
		}

		private bool DidPlayerWin()
		{
			return !(purses[currentPlayer] == 6);
		}

		public PlayerStatus GetCurrentPlayerStatus()
		{
			return playersStatus[currentPlayer];
		}

		public void SwitchToNextplayer()
		{
			currentPlayer++;
			if (currentPlayer == playersStatus.Count) currentPlayer = 0;
		}
	}

}
