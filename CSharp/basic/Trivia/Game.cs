using System;
using System.Collections.Generic;
using System.Linq;
using Trivia.Domain.Dices;
using Trivia.Domain.Dices.Events;
using Trivia.Domain.PlayerContexts;
using Trivia.Domain.PlayerContexts.Events;
using Trivia.Domain.Players;
using Trivia.Domain.Players.Events;

namespace Trivia
{
    public class Game : IDisposable
    {
        List<PlayerContext> _players = new List<PlayerContext>();
        DiceToAnswer _diceToAnswer = new DiceToAnswer(9);

        int[] places = new int[6];

        LinkedList<string> popQuestions = new LinkedList<string>();
        LinkedList<string> scienceQuestions = new LinkedList<string>();
        LinkedList<string> sportsQuestions = new LinkedList<string>();
        LinkedList<string> rockQuestions = new LinkedList<string>();

        int currentPlayer = -1;

        public Game()
        {
            PlayerEvents.OnPlayerTriggered += OnPlayerTriggered;
            PlayerContextEvents.OnPlayerContextTriggered += OnPlayerContextTriggered;
            DiceEvents.OnDiceTriggered += OnDiceTriggered;

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

        public bool Add(String playerName)
        {
            var newPlayer = new Player(playerName);
            _players.Add(new PlayerContext(newPlayer));
            places[HowManyPlayers()] = 0;

            Console.WriteLine(playerName + " was Added");
            Console.WriteLine("They are player number " + _players.Count);
            return true;
        }

        public int HowManyPlayers()
        {
            return _players.Count;
        }

        public void Roll(int roll)
        {
            Console.WriteLine(_players[currentPlayer] + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (_players[currentPlayer].IsPrisoner)
            {
                if (roll % 2 != 0)
                {
                    _players[currentPlayer].Release();
                    places[currentPlayer] = places[currentPlayer] + roll;
                    if (places[currentPlayer] > 11) places[currentPlayer] = places[currentPlayer] - 12;

                    Console.WriteLine(_players[currentPlayer]
                            + "'s new location is "
                            + places[currentPlayer]);
                    Console.WriteLine("The category is " + CurrentCategory());
                    AskQuestion();
                }
                else
                {
                    Console.WriteLine(_players[currentPlayer] + " is not getting out of the penalty box");
                }

            }
            else
            {

                places[currentPlayer] = places[currentPlayer] + roll;
                if (places[currentPlayer] > 11) places[currentPlayer] = places[currentPlayer] - 12;

                Console.WriteLine(_players[currentPlayer]
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

        public bool DidPlayerWin()
        {
            return !(_players[currentPlayer].Score == 6);
        }

        public void RollDiceToAnswer() 
        {
            _players[currentPlayer].Player.RollDice(_diceToAnswer);
        }

        public void SwichToNextPlayer(string playerName)
		{
            var newCurrentPlayer = _players.Single(p => p.Player.Name == playerName);
            currentPlayer = _players.IndexOf(newCurrentPlayer);
        }

        public PlayerContext GetCurrentPlayerContext()
        {
            return _players[currentPlayer];
        }

        private void OnPlayerTriggered(IPlayerEvent playerEvent)
		{
			switch (playerEvent)
			{
                case PlayerAnswerdCorrectlyEvent _:
                    Console.WriteLine("Answer was correct!!!!");
                    _players[currentPlayer].IncreaseScore();
                    return;
                case PlayerAnswerdBadlyEvent _:
                    Console.WriteLine("Question was incorrectly answered");
                    _players[currentPlayer].Imprison();
                    return;
            }
		}

        private void OnPlayerContextTriggered(IPlayerContextEvent playerContextEvent)
        {
			switch (playerContextEvent)
			{
                case PlayerContextImprisonedEvent _:
                    _players[currentPlayer] = playerContextEvent.PlayerContext;
                    Console.WriteLine(_players[currentPlayer].Player.Name + " was sent to the penalty box");
                    return;
                case PlayerContextScoreIncreasedEvent _:
                    _players[currentPlayer] = playerContextEvent.PlayerContext;
                    Console.WriteLine(_players[currentPlayer].Player.Name
                        + " now has "
                        + _players[currentPlayer].Score
                        + " Gold Coins.");
                    return;
                case PlayerContextReleasedEvent _:
                    _players[currentPlayer] = playerContextEvent.PlayerContext;
                    Console.WriteLine(_players[currentPlayer] + " is getting out of the penalty box");
                    return;
            }
        }

        private void OnDiceTriggered(IDiceEvent diceEvent)
        {
            switch (diceEvent)
            {
                case DiceRolledToAnswerEvent _:
                    _players[currentPlayer].Player.Answer(diceEvent.Score);
                    return;
            }
        }

        public void Dispose()
        {
            PlayerEvents.OnPlayerTriggered -= OnPlayerTriggered;
            PlayerContextEvents.OnPlayerContextTriggered -= OnPlayerContextTriggered;
            DiceEvents.OnDiceTriggered -= OnDiceTriggered;
        }
    }

}
