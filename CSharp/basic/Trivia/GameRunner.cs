using System;
using System.Collections.Generic;

namespace Trivia
{
    public class GameRunner
    {

        private static bool isWinner;

        public static void Main(String[] args)
        {
            IList<string> players = new string[]
            {
                "Chet",
                "Pat",
                "Sue"
            };

            Game aGame = new Game();
            Random rand = new Random();
            int currentPlayer = -1;

            foreach (string player in players)
                aGame.AddPlayer(player);

            do
            {
                currentPlayer++;
                string currentPlayerName = GetCurrentPlayer(players, currentPlayer);
                aGame.SwitchToNextPlayer(currentPlayerName);
                aGame.Roll(rand.Next(5) + 1);
                aGame.Answer(currentPlayerName, rand.Next(9));
                isWinner = aGame.PlayerWin(currentPlayerName);

            } while (!isWinner);

        }

        private static string GetCurrentPlayer(IList<string> players, int currentPlayer)
		{
            if (currentPlayer == players.Count) 
                currentPlayer = 0;

            return players[currentPlayer];
        }
    }

}
