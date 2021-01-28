using System;

namespace Trivia.Domain.Dices
{
	public class Dice
	{
		private int _maxNumber { get; }

		private Random _rand = new Random();

		public Dice(int maxNumber)
		{
			_maxNumber = maxNumber;
		}

		public int GetRollingScore()
		{
			return _rand.Next(_maxNumber);
		}
	}
}
