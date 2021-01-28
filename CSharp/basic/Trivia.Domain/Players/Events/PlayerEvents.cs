namespace Trivia.Domain.Players.Events
{
	public delegate void PlayerTriggered(IPlayerEvent playerEvent);

	public static class PlayerEvents
	{
		public static event PlayerTriggered OnPlayerTriggered;

		public static void RaiseEvent(IPlayerEvent playerEvent)
		{
			OnPlayerTriggered.Invoke(playerEvent);
		}
	}
}
