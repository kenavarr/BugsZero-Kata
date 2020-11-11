using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Trivia.Domain.Games;
using Trivia.Domain.Games.Events;
using Trivia.Domain.Players;
using Trivia.Domain.Players.Events;

namespace Trivia.Flow
{
	public class GameFlow
	{
		private IGame _game { get; set; }

		public GameFlow()
		{
			GameEvent.OnGameEventTrigered += new GameEventTrigered(OnGameEventTrigered);
			PlayerEvent.OnPlayerEventTrigered += new PlayerEventTrigered(OnPlayerEventTrigered);
		}
		public void Play()
		{
			Game.Create();
			InvitePlayers();
		}

		private void InvitePlayers()
		{
			Player.Create("Chet");
			Player.Create("Pat");
			Player.Create("Sue");

			while(WaitingPlayers("Chet", "Pat", "Sue"))
			{
				Thread.Sleep(TimeSpan.FromSeconds(1));
			}
		}

		private bool WaitingPlayers(params string[] players)
		{
			if(_game == null)
				return true;

			return players.Select(p => _game.Players.Any(g => g.Name == p)).Any(b => !b);
		}

		private void AddPlayer(PlayerCreated playerCreated)
		{
			NewPlayer newPlayer = playerCreated.Player;
			do
			{
				if (_game != null && _game is NewGame)
					Game.AddPlayer((NewGame)_game, newPlayer);
				else
					Thread.Sleep(TimeSpan.FromSeconds(1));

			} while (_game == null);
		}

		private void OnGameEventTrigered(IGameEvent gameEvent)
		{
			switch (gameEvent)
			{
				case GameCreated gameCreated:
					_game = gameCreated.Game;
					return;
				case GamePlayerAdded gamePlayerAdded:
					_game = gamePlayerAdded.Game;
					return;
				default:
					return;
			}
		}

		private void OnPlayerEventTrigered(IPlayerEvent playerEvent)
		{
			switch (playerEvent)
			{
				case PlayerCreated playerCreated:
					AddPlayer(playerCreated);
					return;
				default:
					return;
			};
		}

		~GameFlow()
		{
			GameEvent.OnGameEventTrigered -= new GameEventTrigered(OnGameEventTrigered);
			PlayerEvent.OnPlayerEventTrigered -= new PlayerEventTrigered(OnPlayerEventTrigered);
		}
	}
}
