using Trivia.Domain.Players.Events;

namespace Trivia.Domain.Players
{
	public static class PlayerAggregate
	{
		public static void Create(string playerName)
		{
			PlayerEvents.RaiseEvent(new PlayerAddedEvent(new Player(playerName)));
		}

		public static void Answer(this Player player, int diceScore)
		{
			if(diceScore != 7)
				PlayerEvents.RaiseEvent(new PlayerAnswerdCorrectlyEvent(player));
			else
				PlayerEvents.RaiseEvent(new PlayerAnswerdBadlyEvent(player));
		}
	}
}
