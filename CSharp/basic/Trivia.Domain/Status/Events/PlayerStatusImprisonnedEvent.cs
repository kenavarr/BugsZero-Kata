namespace Trivia.Domain.Status.Events
{
	public class PlayerStatusImprisonnedEvent : IPlayerStatusEvent
	{
		public PlayerStatus PlayerStatus { get; }

		public PlayerStatusImprisonnedEvent(PlayerStatus playerStatus)
		{
			PlayerStatus = playerStatus;
		}
	}
}
