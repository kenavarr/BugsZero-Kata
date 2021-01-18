using Trivia.Domain.Players.Events;
using Trivia.Domain.Status.Events;

namespace Trivia.Domain.Status
{
	public static class PlayerStatusAggregate
	{
		public static void InitAggregate()
		{
			PlayerEvents.OnPlayerTriggered += OnPlayerTriggered;
		}

		public static void FinalizeAggregate()
		{
			PlayerEvents.OnPlayerTriggered -= OnPlayerTriggered;
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

		private static void OnPlayerTriggered(IPlayerEvent playerEvent)
		{
			switch (playerEvent)
			{
				case PlayerAddedEvent playerAdded:
					PlayerStatusEvents.RaiseEvent(new PlayerStatusCreatedEvent(new PlayerStatus(playerAdded.Player, 0, false)));
					return;
			}
		}
	}
}
