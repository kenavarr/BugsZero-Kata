namespace Trivia.Domain.Games.Events
{
	public class GamePlayerAdded : IGameEvent
	{
		public NewGame Game { get; }

		public GamePlayerAdded(NewGame newGame)
		{
			Game = newGame;
		}
	}
}
