namespace Trivia.Domain.PlayerContexts.Events
{
	public class PlayerContextSwichedPositionEvent : IPlayerContextEvent
	{
		public PlayerContext PlayerContext { get; }

		public PlayerContextSwichedPositionEvent(PlayerContext playerContext)
		{
			PlayerContext = playerContext;
		}
	}
}
