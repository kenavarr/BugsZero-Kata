using FluentAssertions;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using Trivia.Domain.Dices.Events;
using Trivia.Tests.Contexts;

namespace Trivia.Tests.Steps
{
    [Binding]
    [Scope(Feature = "RollDiceToAnswer")]
    public class RollDiceToAnswerSteps
    {
        [When(@"'(.*)' fait (.*) à son jet de dé")]
        public void WhenFaitASonJetDeDe(string player, int score)
        {
            DiceEvents.RaiseEvent(new DiceRolledToAnswerEvent(score));
        }
        
        [Then(@"'(.*)' marque un point")]
        public void ThenMarqueUnPoint(string player)
        {
            var playerContext = GameContext.Game.GetCurrentPlayerContext();
            playerContext.Player.Name.Should().Be(player);
            playerContext.Score.Should().Be(1);
        }
        
        [Then(@"'(.*)' ne marque pas de point")]
        public void ThenNeMarquePasDePoint(string player)
        {
            var playerContext = GameContext.Game.GetCurrentPlayerContext();
            playerContext.Player.Name.Should().Be(player);
            playerContext.Score.Should().Be(0);
        }
        
        [Then(@"'(.*)' va en prison")]
        public void ThenVaEnPrison(string player)
        {
            var playerContext = GameContext.Game.GetCurrentPlayerContext();
            playerContext.Player.Name.Should().Be(player);
            playerContext.IsPrisoner.Should().BeTrue();
        }
    }
}
