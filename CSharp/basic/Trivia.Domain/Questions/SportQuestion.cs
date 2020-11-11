namespace Trivia.Domain.Questions
{
	public class SportQuestion : IQuestion
	{
		public QuestionType Type { get; } = QuestionType.Sport;

		public string Label { get; }

		private SportQuestion(string label)
		{
			Label = label;
		}

		public static SportQuestion Create(string label) => new SportQuestion(label);
	}
}
