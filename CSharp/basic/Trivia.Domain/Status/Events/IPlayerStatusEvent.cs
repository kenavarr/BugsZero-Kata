namespace Trivia.Domain.Status.Events
{
	public interface IPlayerStatusEvent
	{
		PlayerStatus PlayerStatus { get; }
	}
}
