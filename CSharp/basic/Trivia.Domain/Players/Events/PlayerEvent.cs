namespace Trivia.Domain.Players.Events
{
	public static class PlayerEvent
	{
        public static event PlayerEventTrigered OnPlayerEventTrigered;

        public static void Raise(IPlayerEvent playerEvent)
        {
            PlayerEventTrigered playerEventTrigered = OnPlayerEventTrigered;
            if (playerEventTrigered == null)
                return;
            playerEventTrigered(playerEvent);
        }        
    }

    public delegate void PlayerEventTrigered(IPlayerEvent gameEvent);
}
