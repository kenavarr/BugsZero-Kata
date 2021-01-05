using Trivia.Domain.Players;

namespace Trivia.Domain.Status
{
	public static class PlayerStatusAggregate
	{
		public static PlayerStatus Init(Player player)
		{
			return new PlayerStatus(player, 0, false);
		}

		public static PlayerStatus Imprison(this PlayerStatus playerStatus)
		{
			return new PlayerStatus(playerStatus.Player, playerStatus.Score, true);
		}

		public static PlayerStatus Release(this PlayerStatus playerStatus)
		{
			return new PlayerStatus(playerStatus.Player, playerStatus.Score, false);
		}

		public static PlayerStatus IncreaseScore(this PlayerStatus playerStatus)
		{
			return new PlayerStatus(playerStatus.Player, playerStatus.Score + 1, playerStatus.IsPrisoner);
		}
	}
}
