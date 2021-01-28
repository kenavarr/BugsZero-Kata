namespace Trivia.Domain.PlayerContexts.Events
{
	public class PlayerContextScoreIncreasedEvent : IPlayerContextEvent
	{
		public PlayerContext PlayerContext { get; }

		public PlayerContextScoreIncreasedEvent(PlayerContext playerContext)
		{
			PlayerContext = playerContext;
		}
	}
}
