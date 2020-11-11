using System;
using System.Collections.Generic;

namespace Trivia.Domain.Questions
{
	public static class Deck
	{
		public static IEnumerable<IQuestion> OpenNewQuestionsDeck()
		{
			Guid deckGuid = Guid.NewGuid();
			List<IQuestion> questions = new List<IQuestion>();
			for (int i = 0; i < 50; i++)
			{
				questions.Add(PopQuestion.Create($"Pop Question {i} - {deckGuid}"));
				questions.Add(ScienceQuestion.Create($"Science Question {i} - {deckGuid}"));
				questions.Add(SportQuestion.Create($"Sport Question {i} - {deckGuid}"));
				questions.Add(RockQuestion.Create($"Rock Question {i} - {deckGuid}"));
			}
			return questions;
		}
	}
}
