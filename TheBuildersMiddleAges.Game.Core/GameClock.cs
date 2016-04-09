using System;
using System.Collections.Generic;

namespace TheBuildersMiddleAges.Game.Core
{
    public class GameClock
    {
        private readonly List<Guid> _players;
        private int _moveNumber = 1;

        public bool ShouldCheckForWin => _moveNumber % _players.Count == 1;

        public GameClock(List<Guid> players)
        {
            _players = players;
        }

        public Guid GetActingPlayerGuid()
        {
            return _players[_moveNumber % _players.Count];
        }
    }
}