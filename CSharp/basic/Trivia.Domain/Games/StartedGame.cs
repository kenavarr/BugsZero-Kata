using System.Collections.Generic;
using Trivia.Domain.Players;
using Trivia.Domain.Questions;

namespace Trivia.Domain.Games
{
	public class StartedGame : IGame
	{
		public List<NewPlayer> Players { get; }

		public List<IQuestion> Questions { get; }

		public StartedGame(NewGame newGame)
		{
			Players = newGame.Players;
			Questions = newGame.Questions;
		}
	}
}
