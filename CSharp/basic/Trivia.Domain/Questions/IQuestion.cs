namespace Trivia.Domain.Questions
{
	public interface IQuestion
	{
		QuestionType Type { get; }
		string Label { get; }
	}
}
