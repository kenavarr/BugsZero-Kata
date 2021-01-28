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
        DiceToSwichPosition _diceToSwichPosition = new DiceToSwichPosition(5, 1);

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

            Console.WriteLine(playerName + " was Added");
            Console.WriteLine("They are player number " + _players.Count);
            return true;
        }

        public void SwichToNextPlayer(string playerName)
        {
            var newCurrentPlayer = _players.Single(p => p.Player.Name == playerName);
            currentPlayer = _players.IndexOf(newCurrentPlayer);
        }

        public int HowManyPlayers()
        {
            return _players.Count;
        }

        public void RollDiceToSwichPosition()
        {
            Console.WriteLine(_players[currentPlayer] + " is the current player");
            _players[currentPlayer].Player.RollDice(_diceToSwichPosition);
        }

        public void RollDiceToAnswer()
        {
            _players[currentPlayer].Player.RollDice(_diceToAnswer);
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
            if (_players[currentPlayer].Position == 0) return "Pop";
            if (_players[currentPlayer].Position == 4) return "Pop";
            if (_players[currentPlayer].Position == 8) return "Pop";
            if (_players[currentPlayer].Position == 1) return "Science";
            if (_players[currentPlayer].Position == 5) return "Science";
            if (_players[currentPlayer].Position == 9) return "Science";
            if (_players[currentPlayer].Position == 2) return "Sports";
            if (_players[currentPlayer].Position == 6) return "Sports";
            if (_players[currentPlayer].Position == 10) return "Sports";
            return "Rock";
        }

        public bool DidPlayerWin()
        {
            return !(_players[currentPlayer].Score == 6);
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
                case PlayerContextImprisonedEvent playerContextImprisoned:
                    _players[currentPlayer] = playerContextImprisoned.PlayerContext;
                    Console.WriteLine(_players[currentPlayer].Player.Name + " was sent to the penalty box");
                    return;
                case PlayerContextScoreIncreasedEvent playerContextScoreIncreased:
                    _players[currentPlayer] = playerContextScoreIncreased.PlayerContext;
                    Console.WriteLine(_players[currentPlayer].Player.Name
                        + " now has "
                        + _players[currentPlayer].Score
                        + " Gold Coins.");
                    return;
                case PlayerContextUnswichedPositionEvent _:
                    Console.WriteLine(_players[currentPlayer] + " is not getting out of the penalty box");
                    return;
                case PlayerContextSwichedPositionEvent playerContextSwichedPosition:
                    _players[currentPlayer] = playerContextSwichedPosition.PlayerContext;
                    Console.WriteLine(_players[currentPlayer]
                            + "'s new location is "
                            + _players[currentPlayer].Position);
                    Console.WriteLine("The category is " + CurrentCategory());
                    AskQuestion();
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
                case DiceRolledToSwichPositionEvent _:
                    Console.WriteLine("They have rolled a " + diceEvent.Score);
                    _players[currentPlayer].SwichPosition(diceEvent.Score);
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
