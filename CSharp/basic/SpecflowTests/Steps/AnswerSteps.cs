using FluentAssertions;
using SpecflowTests.Contexts;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpecflowTests.Steps
{
	[Binding]
    public class AnswerSteps
    {
        [Given(@"Les joueurs de Trivia")]
        public void GivenLesJoueursDeTrivia(Table players)
        {
            var playersName = players.Rows.Select(i => i["Nom"].ToString());
            foreach (string playerName in playersName)
            {
                GameContext.Game.AddPlayer(playerName);
            }
        }

        [Given(@"'(.*)' doit répondre à une question")]
        public void GivenLeJoueurDoitRepondreAUneQuestion(string playername)
        {
            GameContext.Game.SwitchToNextPlayer(playername);
        }

        [When(@"'(.*)' donne la bonne réponse")]
        public void WhenLeJoueurDonneLaBonneReponse(string playerName)
        {
            GameContext.Game.Answer(playerName, 1);
        }
        
        [When(@"'(.*)' donne la mauvaise réponse")]
        public void WhenLeJoueurDonneLaMauvaiseReponse(string playerName)
        {
            GameContext.Game.Answer(playerName, 7);
        }
        
        [Then(@"'(.*)' marque un point")]
        public void ThenLeJoueurMarqueUnPoint(string playername)
        {
            var currentPlayerSatus = GameContext.Game.GetCurrentPlayerStatus();
            currentPlayerSatus.Score.Should().Be(1);
        }
        
        [Then(@"'(.*)' ne marque pas de point")]
        public void ThenLeJoueurNeMarquePasDePoint(string playerName)
        {
            var currentPlayerSatus = GameContext.Game.GetCurrentPlayerStatus();
            currentPlayerSatus.Score.Should().Be(0);
        }
        
        [Then(@"'(.*)' va en prison")]
        public void ThenLeJoueurVaEnPrison(string playerName)
        {
            var currentPlayerSatus = GameContext.Game.GetCurrentPlayerStatus();
            currentPlayerSatus.IsPrisoner.Should().BeTrue();
        }
    }
}
