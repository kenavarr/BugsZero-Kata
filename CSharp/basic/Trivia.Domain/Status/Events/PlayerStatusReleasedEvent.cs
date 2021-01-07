namespace Trivia.Domain.Status.Events
{
	public class PlayerStatusReleasedEvent : IPlayerStatusEvent
	{
		public PlayerStatus PlayerStatus { get; }

		public PlayerStatusReleasedEvent(PlayerStatus playerStatus)
		{
			PlayerStatus = playerStatus;
		}
	}
}
