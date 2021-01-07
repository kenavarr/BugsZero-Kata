using SpecflowTests.Contexts;
using TechTalk.SpecFlow;
using Trivia;

namespace SpecflowTests.Hooks
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
