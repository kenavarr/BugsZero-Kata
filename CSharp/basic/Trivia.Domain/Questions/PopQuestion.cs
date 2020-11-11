namespace Trivia.Domain.Questions
{
	public class PopQuestion : IQuestion
	{
		public QuestionType Type { get; } = QuestionType.Pop;

		public string Label { get; }

		private PopQuestion(string label)
		{
			Label = label;
		}

		public static PopQuestion Create(string label) => new PopQuestion(label);
	}
}
