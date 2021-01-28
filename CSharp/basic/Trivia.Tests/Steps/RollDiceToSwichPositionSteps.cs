using FluentAssertions;
using TechTalk.SpecFlow;
using Trivia.Domain.Dices.Events;
using Trivia.Domain.PlayerContexts;
using Trivia.Domain.PlayerContexts.Events;
using Trivia.Tests.Contexts;

namespace Trivia.Tests.Steps
{
	[Binding]
    [Scope(Feature = "RollDiceToSwichPosition")]
    public class RollDiceToSwichPositionSteps
    {
        [Given(@"'(.*)' est en position (.*)")]
        public void GivenEstEnPosition(string player, int position)
        {
            var currentPlayer = GameContext.Game.GetCurrentPlayerContext();
            PlayerContextEvents.RaiseEvent(new PlayerContextSwichedPositionEvent(new PlayerContext(currentPlayer.Player, currentPlayer.Score, currentPlayer.IsPrisoner, position)));
        }

        [Given(@"'(.*)' est en prison")]
        public void GivenEstEnPosition(string player)
        {
            var currentPlayer = GameContext.Game.GetCurrentPlayerContext();
            currentPlayer.Imprison();
        }

        [When(@"'(.*)' fait (.*) à son jet de dé")]
        public void WhenFaitASonJetDeDe(string player, int score)
        {
            DiceEvents.RaiseEvent(new DiceRolledToSwichPositionEvent(score));
        }
        
        [Then(@"'(.*)' arrive à la position (.*) du plateau")]
        public void ThenArriveALaPositionDuPlateau(string player, int position)
        {
            var playerContext = GameContext.Game.GetCurrentPlayerContext();
            playerContext.Player.Name.Should().Be(player);
            playerContext.Position.Should().Be(position);
        }

        [Then(@"'(.*)' ne change pas de position")]
        public void ThenNeChangePasDePosition(string player)
        {
            var playerContext = GameContext.Game.GetCurrentPlayerContext();
            playerContext.Player.Name.Should().Be(player);
            playerContext.Position.Should().Be(0);
        }
    }
}
