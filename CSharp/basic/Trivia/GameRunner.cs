using System;
using System.Collections.Generic;

namespace Trivia
{
    public class GameRunner
    {

        private static bool notAWinner;

        public static void Main(String[] args)
        {
            IList<string> players = new string[]
            {
                "Chet",
                "Pat",
                "Sue"
            };

            int currentPlayer = -1;

            Game aGame = new Game();

            foreach (string player in players)
                aGame.Add(player);

            Random rand = new Random();

            do
            {
                currentPlayer++;
                aGame.SwichToNextPlayer(GetCurrentPlayer(players, currentPlayer));
                aGame.Roll(rand.Next(5) + 1);
                aGame.RollDiceToAnswer();
                notAWinner = aGame.DidPlayerWin();
            } while (notAWinner);

        }

        private static string GetCurrentPlayer(IList<string> players, int currentPlayer)
        {
            if (currentPlayer == players.Count)
                currentPlayer = 0;

            return players[currentPlayer];
        }
    }

}
