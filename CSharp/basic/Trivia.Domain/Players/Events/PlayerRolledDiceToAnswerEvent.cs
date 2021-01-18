namespace Trivia.Domain.Players.Events
{
	public class PlayerRolledDiceToAnswerEvent : IPlayerEvent
	{
		public Player Player { get; }

		public int DiceResult { get; }

		public PlayerRolledDiceToAnswerEvent(Player player, int diceResult)
		{
			Player = player;
			DiceResult = diceResult;
		}
	}
}
