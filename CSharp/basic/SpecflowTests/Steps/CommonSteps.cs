using SpecflowTests.Contexts;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpecflowTests.Steps
{
	[Binding]
    public class CommonSteps
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
    }
}
