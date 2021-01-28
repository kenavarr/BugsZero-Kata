using Trivia.Domain.Dices;
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

		public void RollDice(Dice dice)
		{
			dice.GetRollingScore();
		}

		public void Answer(int diceScore)
		{
			if (diceScore == 7)
				PlayerEvents.RaiseEvent(new PlayerAnswerdBadlyEvent(this));
			else
				PlayerEvents.RaiseEvent(new PlayerAnswerdCorrectlyEvent(this));
		}
	}
}
