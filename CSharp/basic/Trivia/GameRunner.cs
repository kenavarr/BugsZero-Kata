using System;

namespace Trivia
{
    public class GameRunner
    {

        private static bool notAWinner;

        public static void Main(String[] args)
        {
            Game aGame = new Game();

            aGame.AddPlayer("Chet");
            aGame.AddPlayer("Pat");
            aGame.AddPlayer("Sue");

            Random rand = new Random();

            do
            {

                aGame.SwitchToNextplayer();
                aGame.Roll(rand.Next(5) + 1);
                notAWinner = aGame.Answer(rand.Next(9));

            } while (notAWinner);

        }


    }

}
