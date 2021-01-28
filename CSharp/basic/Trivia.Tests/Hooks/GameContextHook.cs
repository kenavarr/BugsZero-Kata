using TechTalk.SpecFlow;
using Trivia.Tests.Contexts;

namespace Trivia.Tests.Hooks
{
	[Binding]
	public class GameContextHook
	{
		[BeforeScenario]
		public void InitGame()
		{
			GameContext.Game = new Game();
		}

		[AfterScenario]
		public void DisposeGame()
		{
			GameContext.Game.Dispose();
		}
	}
}
