﻿using System.Collections.Generic;
using Trivia.Domain.Players;
using Trivia.Domain.Questions;

namespace Trivia.Domain.Games
{
	public interface IGame
	{
		List<NewPlayer> Players { get; }
		List<IQuestion> Questions { get; }
	}
}
