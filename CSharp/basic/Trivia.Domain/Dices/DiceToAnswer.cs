using System;
using Trivia.Domain.Dices.Events;

namespace Trivia.Domain.Dices
{
	public class DiceToAnswer : IDice
	{
		private int _maxNumber { get; }

		private Random _rand = new Random();

		public DiceToAnswer(int maxNumber)
		{
			_maxNumber = maxNumber;
		}

		public void GetRollingScore()
		{
			DiceEvents.RaiseEvent(new DiceRolledToAnswerEvent(_rand.Next(_maxNumber)));
		}
	}
}
