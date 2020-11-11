namespace Trivia.Domain.Players
{
	public class NewPlayer
	{
		public string Name { get; }

		private NewPlayer(string name)
		{
			Name = name;
		}

		public static NewPlayer Create(string nickname) => new NewPlayer(nickname);
	}
}
