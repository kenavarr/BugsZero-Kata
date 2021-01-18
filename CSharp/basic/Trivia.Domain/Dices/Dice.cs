using System;

namespace Trivia.Domain.Dices
{
	internal class Dice
	{
		internal int MaxNumber { get; }

		internal int Affix { get; }

		internal Dice(int maxNumber)
		{
			MaxNumber = maxNumber;
		}

		internal Dice(int maxNumber, int affix)
		{
			MaxNumber = maxNumber;
			Affix = affix;
		}
	}
}
