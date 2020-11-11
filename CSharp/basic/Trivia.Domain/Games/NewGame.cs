using System.Collections.Generic;
using Trivia.Domain.Players;
using Trivia.Domain.Questions;

namespace Trivia.Domain.Games
{
	public class NewGame : IGame
	{
		public List<NewPlayer> Players { get; } = new List<NewPlayer>();

		public List<IQuestion> Questions { get; }

		public NewGame()
		{
		}
	}
}
