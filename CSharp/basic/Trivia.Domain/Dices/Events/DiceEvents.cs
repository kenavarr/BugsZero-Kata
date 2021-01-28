namespace Trivia.Domain.Dices.Events
{
	public delegate void DiceTriggered(IDiceEvent diceEvent);

	public static class DiceEvents
	{
		public static event DiceTriggered OnDiceTriggered;

		public static void RaiseEvent(IDiceEvent diceEvent)
		{
			OnDiceTriggered.Invoke(diceEvent);
		}
	}
}
