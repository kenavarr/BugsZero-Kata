namespace Trivia.Domain.Questions
{
	public class ScienceQuestion : IQuestion
	{
		public QuestionType Type { get; } = QuestionType.Science;

		public string Label { get; }

		private ScienceQuestion(string label)
		{
			Label = label;
		}

		public static ScienceQuestion Create(string label) => new ScienceQuestion(label);
	}
}
