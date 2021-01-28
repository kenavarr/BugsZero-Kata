namespace Trivia.Domain.PlayerContexts.Events
{
	public class PlayerContextReleasedEvent : IPlayerContextEvent
	{
		public PlayerContext PlayerContext { get; }

		public PlayerContextReleasedEvent(PlayerContext playerContext)
		{
			PlayerContext = playerContext;
		}
	}
}
