using FluentAssertions;
using SpecflowTests.Contexts;
using TechTalk.SpecFlow;
using Trivia.Domain.Players;

namespace SpecflowTests.Steps
{
	[Binding]
    [Scope(Feature = "RollDiceToAnswer")]
    public class RoolDiceToAnswerSteps
    {
        [When(@"'(.*)' fait (.*) à son jet de dé")]
        public void WhenLeJoueurFaitXASonJetDeDe(string playerName, int diceScore)
        {
            Player player = GameContext.Game.GetPlayerStatus(playerName).Player;
            GameContext.RaisePlayerRolledDiceToAnswer(player, diceScore);
        }

        [Then(@"'(.*)' marque un point")]
        public void ThenLeJoueurMarqueUnPoint(string playerName)
        {
            var currentPlayerSatus = GameContext.Game.GetPlayerStatus(playerName);
            currentPlayerSatus.Score.Should().Be(1);
        }
        
        [Then(@"'(.*)' ne marque pas de point")]
        public void ThenLeJoueurNeMarquePasDePoint(string playerName)
        {
            var currentPlayerSatus = GameContext.Game.GetPlayerStatus(playerName);
            currentPlayerSatus.Score.Should().Be(0);
        }
        
        [Then(@"'(.*)' va en prison")]
        public void ThenLeJoueurVaEnPrison(string playerName)
        {
            var currentPlayerSatus = GameContext.Game.GetPlayerStatus(playerName);
            currentPlayerSatus.IsPrisoner.Should().BeTrue();
        }
    }
}
