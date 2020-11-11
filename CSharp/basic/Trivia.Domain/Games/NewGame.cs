using System.Collections.Generic;
using Trivia.Domain.Players;
using Trivia.Domain.Questions;

namespace Trivia.Domain.Games
{
	public class NewGame : IGame
	{
		public List<Player> Players { get; }

		public List<IQuestion> Questions { get; }

		public NewGame()
		{
		}
	}
}
