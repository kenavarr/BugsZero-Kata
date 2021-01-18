using FluentAssertions;
using SpecflowTests.Contexts;
using TechTalk.SpecFlow;
using Trivia.Domain.Players;

namespace SpecflowTests.Steps
{
	[Binding]
    [Scope(Feature = "WinGame")]
    public class WinGameSteps
    {
        [Given(@"'(.*)' a (.*) points")]
        public void GivenLeJoueurAXPoints(string playerName, int score)
        {
            Player player = GameContext.Game.GetPlayerStatus(playerName).Player;

            for(int i = 0; i < score; i++)
			{
                GameContext.RaisePlayerRolledDiceToAnswer(player, 1);
			}
        }

        [When(@"'(.*)' gagne un nouveau point")]
        public void WhenLeJoueurGagneUnNouveauPoint(string playerName)
        {
            Player player = GameContext.Game.GetPlayerStatus(playerName).Player;
            GameContext.RaisePlayerAnsweredCorrectly(player);
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
