using TechTalk.SpecFlow;

namespace SpecflowTests.Steps
{
	[Binding]
    public class QuestionAnswerFeatureSteps
    {
        [Given(@"Les joueurs de Trivia")]
        public void GivenLesJoueursDeTrivia(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"La question ""(.*)""")]
        public void GivenLaQuestion(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Le joueur ""(.*)"" pose la question ""(.*)"" au joueur ""(.*)""")]
        public void WhenLeJoueurPoseLaQuestionAuJoueur(string p0, string p1, string p2)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Le joueur ""(.*)"" donne la bonne réponse à la question ""(.*)""")]
        public void WhenLeJoueurDonneLaBonneReponseALaQuestion(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Le joueur ""(.*)"" donne la mauvaise réponse à la question ""(.*)""")]
        public void WhenLeJoueurDonneLaMauvaiseReponseALaQuestion(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Le joueur ""(.*)"" marque (.*) point supplémentaire")]
        public void ThenLeJoueurMarquePointSupplementaire(string p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Le joueur ""(.*)"" ne marque pas de point")]
        public void ThenLeJoueurNeMarquePasDePoint(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Le joueur ""(.*)"" va en prison")]
        public void ThenLeJoueurVaEnPrison(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
