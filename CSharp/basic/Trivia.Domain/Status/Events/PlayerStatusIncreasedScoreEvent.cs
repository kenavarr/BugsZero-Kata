namespace Trivia.Domain.Status.Events
{
	public class PlayerStatusIncreasedScoreEvent : IPlayerStatusEvent
	{
		public PlayerStatus PlayerStatus { get; }

		public PlayerStatusIncreasedScoreEvent(PlayerStatus playerStatus)
		{
			PlayerStatus = playerStatus;
		}
	}
}
