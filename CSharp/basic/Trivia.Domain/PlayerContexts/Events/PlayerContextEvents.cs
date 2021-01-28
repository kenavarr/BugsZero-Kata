namespace Trivia.Domain.PlayerContexts.Events
{
	public delegate void PlayerContextTriggered(IPlayerContextEvent playerContextEvent);

	public static class PlayerContextEvents
	{
		public static event PlayerContextTriggered OnPlayerContextTriggered;

		public static void RaiseEvent(IPlayerContextEvent playerEvent)
		{
			OnPlayerContextTriggered.Invoke(playerEvent);
		}
	}
}
