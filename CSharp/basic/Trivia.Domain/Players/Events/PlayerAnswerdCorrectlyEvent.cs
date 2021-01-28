namespace Trivia.Domain.Players.Events
{
	public class PlayerAnswerdCorrectlyEvent : IPlayerEvent
	{
		public Player Player { get; }

		public PlayerAnswerdCorrectlyEvent(Player player)
		{
			Player = player;
		}
	}
}
