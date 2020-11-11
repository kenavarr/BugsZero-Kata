using Trivia.Domain.Players.Events;

namespace Trivia.Domain.Players
{
	public static class Player
	{
		public static void Create(string nickname)
		{
			NewPlayer newPlayer = NewPlayer.Create(nickname);
			PlayerEvent.Raise(new PlayerCreated(newPlayer));
		}
	}
}
