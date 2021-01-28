using System;
using System.Collections.Generic;
using System.Linq;
using Trivia.Domain.PlayerContexts;
using Trivia.Domain.PlayerContexts.Events;
using Trivia.Domain.Players;
using Trivia.Domain.Players.Events;

namespace Trivia
{
    public class Game : IDisposable
    {
        List<PlayerContext> players = new List<PlayerContext>();

        int[] places = new int[6];

        bool[] inPenaltyBox = new bool[6];

        LinkedList<string> popQuestions = new LinkedList<string>();
        LinkedList<string> scienceQuestions = new LinkedList<string>();
        LinkedList<string> sportsQuestions = new LinkedList<string>();
        LinkedList<string> rockQuestions = new LinkedList<string>();

        int currentPlayer = -1;

        public Game()
        {
            PlayerEvents.OnPlayerTriggered += OnPlayerTriggered;
            PlayerContextEvents.OnPlayerContextTriggered += OnPlayerContextTriggered;

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
            players.Add(new PlayerContext(newPlayer));
            places[HowManyPlayers()] = 0;
            inPenaltyBox[HowManyPlayers()] = false;

            Console.WriteLine(playerName + " was Added");
            Console.WriteLine("They are player number " + players.Count);
            return true;
        }

        public int HowManyPlayers()
        {
            return players.Count;
        }

        public void Roll(int roll)
        {
            Console.WriteLine(players[currentPlayer] + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (inPenaltyBox[currentPlayer])
            {
                if (roll % 2 != 0)
                {
                    players[currentPlayer].Release();
                    places[currentPlayer] = places[currentPlayer] + roll;
                    if (places[currentPlayer] > 11) places[currentPlayer] = places[currentPlayer] - 12;

                    Console.WriteLine(players[currentPlayer]
                            + "'s new location is "
                            + places[currentPlayer]);
                    Console.WriteLine("The category is " + CurrentCategory());
                    AskQuestion();
                }
                else
                {
                    Console.WriteLine(players[currentPlayer] + " is not getting out of the penalty box");
                }

            }
            else
            {

                places[currentPlayer] = places[currentPlayer] + roll;
                if (places[currentPlayer] > 11) places[currentPlayer] = places[currentPlayer] - 12;

                Console.WriteLine(players[currentPlayer]
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
            return !(players[currentPlayer].Score == 6);
        }

        public void Answer(int diceScore) 
        {
            players[currentPlayer].Player.Answer(diceScore);
        }

        public void SwichToNextPlayer()
		{
            currentPlayer++;
            if (currentPlayer == players.Count) 
                currentPlayer = 0;
        }

        public PlayerContext GetCurrentPlayerContext()
        {
            return players[currentPlayer];
        }

        private void OnPlayerTriggered(IPlayerEvent playerEvent)
		{
			switch (playerEvent)
			{
                case PlayerAnswerdCorrectlyEvent _:
                    Console.WriteLine("Answer was correct!!!!");
                    players[currentPlayer].IncreaseScore();
                    return;
                case PlayerAnswerdBadlyEvent _:
                    Console.WriteLine("Question was incorrectly answered");
                    players[currentPlayer].Imprison();
                    return;
            }
		}

        private void OnPlayerContextTriggered(IPlayerContextEvent playerContextEvent)
        {
			switch (playerContextEvent)
			{
                case PlayerContextImprisonedEvent _:
                    players[currentPlayer] = playerContextEvent.PlayerContext;
                    Console.WriteLine(players[currentPlayer].Player.Name + " was sent to the penalty box");
                    return;
                case PlayerContextScoreIncreasedEvent _:
                    players[currentPlayer] = playerContextEvent.PlayerContext;
                    Console.WriteLine(players[currentPlayer].Player.Name
                        + " now has "
                        + players[currentPlayer].Score
                        + " Gold Coins.");
                    return;
                case PlayerContextReleasedEvent _:
                    players[currentPlayer] = playerContextEvent.PlayerContext;
                    Console.WriteLine(players[currentPlayer] + " is getting out of the penalty box");
                    return;
            }
        }

        public void Dispose()
        {
            PlayerEvents.OnPlayerTriggered -= OnPlayerTriggered;
            PlayerContextEvents.OnPlayerContextTriggered -= OnPlayerContextTriggered;
        }
    }

}
