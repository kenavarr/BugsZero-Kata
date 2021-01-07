namespace Trivia.Domain.Status.Events
{
	public class PlayerStatusCreatedEvent : IPlayerStatusEvent
	{
		public PlayerStatus PlayerStatus { get; }

		public PlayerStatusCreatedEvent(PlayerStatus playerStatus)
		{
			PlayerStatus = playerStatus;
		}
	}
}
