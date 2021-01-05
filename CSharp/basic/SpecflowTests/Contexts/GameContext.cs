using Trivia;

namespace SpecflowTests.Contexts
{
	public class GameContext
	{
		public Game Game { get; }

		public GameContext()
		{
			Game = new Game();
		}
	}
}
