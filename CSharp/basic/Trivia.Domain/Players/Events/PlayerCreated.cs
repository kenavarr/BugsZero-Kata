namespace Trivia.Domain.Players.Events
{
	public class PlayerCreated : IPlayerEvent
	{
		public NewPlayer Player { get; }

		public PlayerCreated(NewPlayer newPlayer)
		{
			Player = newPlayer;
		}
	}
}
