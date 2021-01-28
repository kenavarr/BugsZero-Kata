using Trivia.Domain.PlayerContexts.Events;
using Trivia.Domain.Players;

namespace Trivia.Domain.PlayerContexts
{
	public class PlayerContext
	{
		public Player Player { get; }

		public uint Score { get; }

		public bool IsPrisoner { get; }

		public PlayerContext(Player player)
			: this(player, 0, false)
		{
		}

		private PlayerContext(Player player, uint score, bool isPrisoner)
		{
			Player = player;
			Score = score;
			IsPrisoner = isPrisoner;
		}

		public void Imprison()
		{
			PlayerContextEvents.RaiseEvent(new PlayerContextImprisonedEvent(new PlayerContext(Player, Score, true)));
		}

		public void Release()
		{
			PlayerContextEvents.RaiseEvent(new PlayerContextReleasedEvent(new PlayerContext(Player, Score, false)));
		}

		public void IncreaseScore()
		{
			PlayerContextEvents.RaiseEvent(new PlayerContextScoreIncreasedEvent(new PlayerContext(Player, Score + 1, IsPrisoner)));
		}
	}
}
