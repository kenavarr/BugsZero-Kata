using Trivia.Domain.Players;

namespace Trivia.Domain.Games
{
	public static class Game
	{
		public static NewGame Create() => new NewGame();

		public static NewGame AddPlayer(this NewGame newGame, Player player)
		{
			if (!newGame.Players.Contains(player))
				newGame.Players.Add(player);

			return newGame;
		}

		public static NewGame RemovePlayer(this NewGame newGame, Player player)
		{
			if (newGame.Players.Contains(player))
				newGame.Players.Remove(player);

			return newGame;
		}
	}
}
