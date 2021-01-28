using Trivia.Domain.Players.Events;

namespace Trivia.Domain.Players
{
	public class Player
	{
		public string Name { get; }

		public Player(string playerName)
		{
			Name = playerName;
		}

		public void Answer(int diceScore)
		{
			if (diceScore != 7)
				PlayerEvents.RaiseEvent(new PlayerAnswerdCorrectlyEvent(this));
			else
				PlayerEvents.RaiseEvent(new PlayerAnswerdBadlyEvent(this));
		}
	}
}
