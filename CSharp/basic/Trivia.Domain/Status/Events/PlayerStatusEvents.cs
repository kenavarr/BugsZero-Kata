namespace Trivia.Domain.Status.Events
{
	public delegate void PlayerStatusTriggered(IPlayerStatusEvent playerStatusEvent);

	public static class PlayerStatusEvents
	{
		public static event PlayerStatusTriggered OnPlayerStatusTriggered;

		public static void RaiseEvent(IPlayerStatusEvent playerStatusEvent)
		{
			OnPlayerStatusTriggered.Invoke(playerStatusEvent);
		}
	}
}
