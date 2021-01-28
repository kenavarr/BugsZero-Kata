namespace Trivia.Domain.Players.Events
{
	public class PlayerAnswerdBadlyEvent : IPlayerEvent
	{
		public Player Player { get; }

		public PlayerAnswerdBadlyEvent(Player player)
		{
			Player = player;
		}
	}
}
