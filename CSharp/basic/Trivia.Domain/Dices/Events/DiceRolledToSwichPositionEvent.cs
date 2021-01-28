namespace Trivia.Domain.Dices.Events
{
	public class DiceRolledToSwichPositionEvent : IDiceEvent
	{
		public int Score { get; }

		public DiceRolledToSwichPositionEvent(int score)
		{
			Score = score;
		}
	}
}
