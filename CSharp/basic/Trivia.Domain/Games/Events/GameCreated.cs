namespace Trivia.Domain.Games.Events
{
	public class GameCreated : IGameEvent
	{
		public NewGame Game { get; }

		public GameCreated(NewGame newGame)
		{
			Game = newGame;
		}
	}
}
