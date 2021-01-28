using FluentAssertions;
using System.Linq;
using TechTalk.SpecFlow;
using Trivia.Tests.Contexts;

namespace Trivia.Tests.Steps
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
                GameContext.Game.Add(playerName);
            }
        }
        
        [Given(@"Un joueur doit répondre à une question")]
        public void GivenUnJoueurDoitRepondreAUneQuestion()
        {
            GameContext.Game.SwichToNextPlayer();
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
            var playerContext = GameContext.Game.GetCurrentPlayerContext();
            playerContext.Score.Should().Be(1);
        }
        
        [Then(@"Le joueur ne marque pas de point")]
        public void ThenLeJoueurNeMarquePasDePoint()
        {
            var playerContext = GameContext.Game.GetCurrentPlayerContext();
            playerContext.Score.Should().Be(0);
        }
        
        [Then(@"Le joueur va en prison")]
        public void ThenLeJoueurVaEnPrison()
        {
            var playerContext = GameContext.Game.GetCurrentPlayerContext();
            playerContext.IsPrisoner.Should().BeTrue();
        }
    }
}
