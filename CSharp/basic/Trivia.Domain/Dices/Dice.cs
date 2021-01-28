using System;

namespace Trivia.Domain.Dices
{
	internal class Dice
	{
		private int _maxNumber { get; }

		private Random _rand = new Random();

		internal Dice(int maxNumber)
		{
			_maxNumber = maxNumber;
		}

		public int GetRollingScore()
		{
			return _rand.Next(_maxNumber);
		}
	}
}
