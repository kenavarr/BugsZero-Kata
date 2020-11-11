using System;
using Trivia.Domain.Games;
using Trivia.Domain.Players;
using Trivia.Domain.Questions;

namespace Trivia.Launcher
{
	class GameRunner
	{
        private static bool notAWinner;

        public static void Main(String[] args)
        {
            // Initialisation du jeux
            IGame game = Game.Create()
                .AddPlayer(Player.Create("Chet"))
                .AddPlayer(Player.Create("Pat"))
                .AddPlayer(Player.Create("Sue"))
                .AddDeck(Deck.OpenNewQuestionsDeck());

            OldGame aGame = new OldGame();

            aGame.Add("Chet");
            aGame.Add("Pat");
            aGame.Add("Sue");

            Random rand = new Random();

            do
            {
                aGame.Roll(rand.Next(5) + 1);

                if (rand.Next(9) == 7)
                    notAWinner = aGame.WrongAnswer();
                else
                    notAWinner = aGame.WasCorrectlyAnswered();

            } while (notAWinner);
        }
    }
}
