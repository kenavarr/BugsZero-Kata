namespace Trivia.Domain.Players
{
	public class Player
	{
		public string Name { get; }

		private Player(string name)
		{
			Name = name;
		}

		public static Player Create(string nickname) => new Player(nickname);
	}
}
