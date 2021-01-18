using Trivia;
using Trivia.Domain.Players;
using Trivia.Domain.Players.Events;

namespace SpecflowTests.Contexts
{
	public static class GameContext
	{
		public static Game Game { get; set; }

		public static void RaisePlayerRolledDiceToAnswer(Player player, int diceResult)
		{
			PlayerEvents.RaiseEvent(new PlayerRolledDiceToAnswerEvent(player, diceResult));
		}

		public static void RaisePlayerAnsweredCorrectly(Player player)
		{
			PlayerEvents.RaiseEvent(new PlayerAnswerdCorrectlyEvent(player));
		}
	}
}
