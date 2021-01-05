using Trivia.Domain.Players;

namespace Trivia.Domain.Status
{
	public class PlayerStatus
	{
		public Player Player { get; }

		public int Score { get; }

		public bool IsPrisoner { get; }

		public PlayerStatus(Player player, int score, bool isPrisoner)
		{
			Player = player;
			Score = score;
			IsPrisoner = isPrisoner;
		}
	}
}
