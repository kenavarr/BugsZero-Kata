namespace Trivia.Domain.Questions
{
	public class RockQuestion : IQuestion
	{
		public QuestionType Type { get; } = QuestionType.Rock;

		public string Label { get; }

		private RockQuestion(string label)
		{
			Label = label;
		}

		public static RockQuestion Create(string label) => new RockQuestion(label);
	}
}
