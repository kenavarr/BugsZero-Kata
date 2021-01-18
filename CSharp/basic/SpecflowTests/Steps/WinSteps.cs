using FluentAssertions;
using SpecflowTests.Contexts;
using TechTalk.SpecFlow;

namespace SpecflowTests.Steps
{
	[Binding]
    [Scope(Feature = "Win")]
    public class WinSteps
    {
        [Given(@"'(.*)' a (.*) points")]
        public void GivenLeJoueurAXPoints(string playerName, int score)
        {
            for(int i = 0; i < score; i++)
			{
                GameContext.Game.Answer(playerName, 1);
			}
        }
        
        [Then(@"'(.*)' a gagné la partie")]
        public void ThenLeJoueurAGagneLaPartie(string playerName)
        {
            GameContext.Game.PlayerWin(playerName).Should().BeTrue();
        }

        [Then(@"'(.*)' n'a pas gagné la partie")]
        public void ThenLeJoueurNAPasGagneLaPartie(string playerName)
        {
            GameContext.Game.PlayerWin(playerName).Should().BeFalse();
        }
    }
}
