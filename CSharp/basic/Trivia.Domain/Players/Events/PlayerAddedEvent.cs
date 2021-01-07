namespace Trivia.Domain.Players.Events
{
	public class PlayerAddedEvent : IPlayerEvent
	{
		public Player Player { get; }

		public PlayerAddedEvent(Player player)
		{
			Player = player;
		}
	}
}
