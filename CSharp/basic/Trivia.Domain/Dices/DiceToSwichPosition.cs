using System;
using Trivia.Domain.Dices.Events;

namespace Trivia.Domain.Dices
{
	public class DiceToSwichPosition : IDice
	{
		private int _maxNumber { get; }

		private int _bonus { get; }

		private Random _rand = new Random();

		public DiceToSwichPosition(int maxNumber, int bonus)
		{
			_maxNumber = maxNumber;
			_bonus = bonus;
		}

		public void GetRollingScore()
		{
			DiceEvents.RaiseEvent(new DiceRolledToSwichPositionEvent(_rand.Next(_maxNumber) + _bonus));
		}
	}
}
