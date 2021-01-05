using FluentAssertions;
using SpecflowTests.Contexts;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpecflowTests.Steps
{
	[Binding]
    public class AnswerSteps
    {
        private GameContext GameContext = new GameContext();

        [Given(@"Les joueurs de Trivia")]
        public void GivenLesJoueursDeTrivia(Table players)
        {
            var playersName = players.Rows.Select(i => i["Nom"].ToString());
            foreach (string playerName in playersName)
            {
                GameContext.Game.AddPlayer(playerName);
            }
        }

        [Given(@"Un joueur doit répondre à une question")]
        public void GivenUnJoueurDoitRepondreAUneQuestion()
        {
            GameContext.Game.SwitchToNextplayer();
        }

        [When(@"Le joueur donne la bonne réponse")]
        public void WhenLeJoueurDonneLaBonneReponse()
        {
            GameContext.Game.Answer(1);
        }
        
        [When(@"Le joueur donne la mauvaise réponse")]
        public void WhenLeJoueurDonneLaMauvaiseReponse()
        {
            GameContext.Game.Answer(7);
        }
        
        [Then(@"Le joueur marque un point")]
        public void ThenLeJoueurMarqueUnPoint()
        {
            var currentPlayerSatus = GameContext.Game.GetCurrentPlayerStatus();
            currentPlayerSatus.Score.Should().Be(1);
        }
        
        [Then(@"Le joueur ne marque pas de point")]
        public void ThenLeJoueurNeMarquePasDePoint()
        {
            var currentPlayerSatus = GameContext.Game.GetCurrentPlayerStatus();
            currentPlayerSatus.Score.Should().Be(0);
        }
        
        [Then(@"Le joueur va en prison")]
        public void ThenLeJoueurVaEnPrison()
        {
            var currentPlayerSatus = GameContext.Game.GetCurrentPlayerStatus();
            currentPlayerSatus.IsPrisoner.Should().BeTrue();
        }
    }
}
