using Trivia.Domain.PlayerContexts.Events;
using Trivia.Domain.Players;

namespace Trivia.Domain.PlayerContexts
{
	public class PlayerContext
	{
		public Player Player { get; }

		public uint Score { get; }

		public bool IsPrisoner { get; }

		public int Position { get; }

		public PlayerContext(Player player)
			: this(player, 0, false, 0)
		{
		}

		public PlayerContext(Player player, uint score, bool isPrisoner, int position)
		{
			Player = player;
			Score = score;
			IsPrisoner = isPrisoner;
			Position = position;
		}

		public void Imprison()
		{
			PlayerContextEvents.RaiseEvent(new PlayerContextImprisonedEvent(new PlayerContext(Player, Score, true, Position)));
		}

		public void IncreaseScore()
		{
			PlayerContextEvents.RaiseEvent(new PlayerContextScoreIncreasedEvent(new PlayerContext(Player, Score + 1, IsPrisoner, Position)));
		}

		public void SwichPosition(int diceScore)
		{
			if (IsPrisoner && diceScore % 2 == 0)
			{
				PlayerContextEvents.RaiseEvent(new PlayerContextUnswichedPositionEvent());
				return;
			}

			PlayerContextEvents.RaiseEvent(new PlayerContextSwichedPositionEvent(new PlayerContext(Player, Score, false, CalculPosition(diceScore))));
		}

		private int CalculPosition(int diceScore)
		{
			int newPosition = Position + diceScore;

			if (newPosition > 11)
				return newPosition - 12;

			return newPosition;
		}
	}
}
