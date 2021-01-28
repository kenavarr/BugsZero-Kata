using System.Linq;
using TechTalk.SpecFlow;
using Trivia.Tests.Contexts;

namespace Trivia.Tests.Steps
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
                GameContext.Game.Add(playerName);
            }
        }

        [Given(@"'(.*)' est le joueur de ce tour")]
        public void GivenEstLeJoueurDeCeTour(string player)
        {
            GameContext.Game.SwichToNextPlayer(player);
        }
    }
}
