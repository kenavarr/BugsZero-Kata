using System.Collections.Generic;
using Trivia.Domain.Games.Events;
using Trivia.Domain.Players;
using Trivia.Domain.Questions;

namespace Trivia.Domain.Games
{
	public class Game
	{
		public Game()
		{
		}

		public static void Create()
		{
			GameEvent.Raise(new GameCreated(new NewGame()));
		}

		public static void AddPlayer(NewGame newGame, NewPlayer player)
		{
			if (!newGame.Players.Contains(player))
			{
				newGame.Players.Add(player);

				GameEvent.Raise(new GamePlayerAdded(newGame));
			}
		}

		public static T AddDeck<T>(T game, IEnumerable<IQuestion> questions)
			where T : IGame
		{
			game.Questions.AddRange(questions);
			return game;
		}

		public static StartedGame Start(NewGame newGame)
		{
			return new StartedGame(newGame);
		}
	}
}
