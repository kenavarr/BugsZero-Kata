namespace Trivia.Domain.PlayerContexts.Events
{
	public class PlayerContextImprisonedEvent : IPlayerContextEvent
	{
		public PlayerContext PlayerContext { get; }

		public PlayerContextImprisonedEvent(PlayerContext playerContext)
		{
			PlayerContext = playerContext;
		}
	}
}
