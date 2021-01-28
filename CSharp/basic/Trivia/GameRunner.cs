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

            do
            {
                currentPlayer = GetCurrentPlayer(players, currentPlayer + 1);
                aGame.SwichToNextPlayer(players[currentPlayer]);
                aGame.RollDiceToSwichPosition();

                if (!aGame.GetCurrentPlayerContext().IsPrisoner)
                    aGame.RollDiceToAnswer();

                notAWinner = aGame.DidPlayerWin();
            } while (notAWinner);

        }

        private static int GetCurrentPlayer(IList<string> players, int nextPlayer)
        {
            if (nextPlayer == players.Count)
                nextPlayer = 0;

            return nextPlayer;
        }
    }

}
