namespace Trivia.Domain.Games.Events
{
	public static class GameEvent
	{
        public static event GameEventTrigered OnGameEventTrigered;

        public static void Raise(IGameEvent gameEvent)
        {
            GameEventTrigered gameEventTrigered = OnGameEventTrigered;
            if (gameEventTrigered == null)
                return;
            gameEventTrigered(gameEvent);
        }        
    }

    public delegate void GameEventTrigered(IGameEvent gameEvent);
}
