using System;
using Trivia.Domain.Dices;
using Trivia.Domain.Players.Events;

namespace Trivia.Domain.Players
{
	public static class PlayerAggregate
	{
		private static Dice _diceToAnswer = new Dice(9);
		private static Dice _diceToSwichPlace = new Dice(5, 1);

		public static void InitAggregate()
		{
			PlayerEvents.OnPlayerTriggered += OnPlayerTriggered;
		}

		public static void FinalizeAggregate()
		{
			PlayerEvents.OnPlayerTriggered -= OnPlayerTriggered;
		}

		public static void JoinTheGame(string playerName)
		{
			PlayerEvents.RaiseEvent(new PlayerJoinedTheGameEvent(new Player(playerName)));
		}

		public static void RollDiceToSwichPlace(this Player player)
		{
			RollDice(_diceToSwichPlace);
		}

		public static void RollDiceToAnswer(this Player player)
		{
			PlayerEvents.RaiseEvent(new PlayerRolledDiceToAnswerEvent(player, RollDice(_diceToAnswer)));
		}

		private static int RollDice(Dice dice)
		{
			Random rand = new Random();
			return rand.Next(dice.MaxNumber) + dice.Affix;
		}

		private static void OnPlayerTriggered(IPlayerEvent playerEvent)
		{
			switch (playerEvent)
			{
				case PlayerRolledDiceToAnswerEvent playerRolledDiceToAnswer:
					if (playerRolledDiceToAnswer.DiceResult == 7)
						PlayerEvents.RaiseEvent(new PlayerAnswerdBadlyEvent(playerRolledDiceToAnswer.Player));
					else
						PlayerEvents.RaiseEvent(new PlayerAnswerdCorrectlyEvent(playerRolledDiceToAnswer.Player));
					return;
			}
		}
	}
}
