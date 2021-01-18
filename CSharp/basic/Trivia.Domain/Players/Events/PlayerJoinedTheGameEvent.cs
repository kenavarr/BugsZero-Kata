namespace Trivia.Domain.Players.Events
{
	public class PlayerJoinedTheGameEvent : IPlayerEvent
	{
		public Player Player { get; }

		public PlayerJoinedTheGameEvent(Player player)
		{
			Player = player;
		}
	}
}
