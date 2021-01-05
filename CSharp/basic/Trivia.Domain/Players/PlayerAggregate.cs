using System;

namespace Trivia.Domain.Players
{
	public static class PlayerAggregate
	{
		public static Player Create(string playerName)
		{
			return new Player(playerName);
		}

		public static bool Answer(this Player player, int diceScore)
		{
			return diceScore != 7;
		}
	}
}
