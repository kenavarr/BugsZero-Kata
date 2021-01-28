namespace Trivia.Domain.Dices.Events
{
	public class DiceRolledToAnswerEvent : IDiceEvent
	{
		public int Score { get; }

		public DiceRolledToAnswerEvent(int score)
		{
			Score = score;
		}
	}
}
