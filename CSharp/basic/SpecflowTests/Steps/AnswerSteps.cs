using FluentAssertions;
using SpecflowTests.Contexts;
using TechTalk.SpecFlow;

namespace SpecflowTests.Steps
{
	[Binding]
    [Scope(Feature = "Answer")]
    public class AnswerSteps
    {        
        [When(@"'(.*)' donne la mauvaise réponse")]
        public void WhenLeJoueurDonneLaMauvaiseReponse(string playerName)
        {
            GameContext.Game.Answer(playerName, 7);
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
