using Trivia.Domain.Players;
using Trivia.Domain.Status.Events;

namespace Trivia.Domain.Status
{
	public static class PlayerStatusAggregate
	{
		public static void Init(Player player)
		{
			PlayerStatusEvents.RaiseEvent(new PlayerStatusCreatedEvent(new PlayerStatus(player, 0, false)));
		}

		public static void Imprison(this PlayerStatus playerStatus)
		{
			PlayerStatusEvents.RaiseEvent(new PlayerStatusImprisonnedEvent(new PlayerStatus(playerStatus.Player, playerStatus.Score, true)));
		}

		public static void Release(this PlayerStatus playerStatus)
		{
			PlayerStatusEvents.RaiseEvent(new PlayerStatusImprisonnedEvent(new PlayerStatus(playerStatus.Player, playerStatus.Score, false)));
		}

		public static void IncreaseScore(this PlayerStatus playerStatus)
		{
			PlayerStatusEvents.RaiseEvent(new PlayerStatusIncreasedScoreEvent(new PlayerStatus(playerStatus.Player, playerStatus.Score + 1, playerStatus.IsPrisoner)));
		}
	}
}
