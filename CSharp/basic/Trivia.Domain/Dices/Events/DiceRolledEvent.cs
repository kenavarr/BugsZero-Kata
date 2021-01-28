namespace Trivia.Domain.Dices.Events
{
	public class DiceRolledEvent : IDiceEvent
	{
		public int Score { get; }

		public DiceRolledEvent(int score)
		{
			Score = score;
		}
	}
}
