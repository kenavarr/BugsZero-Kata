using System.Collections.Generic;
using Trivia.Domain.Players;

namespace Trivia.Domain.Games
{
	public class NewGame : IGame
	{
		public List<Player> Players { get; }

		public NewGame()
		{
		}
	}
}
