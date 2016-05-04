using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TheBuildersMiddleAges.Game.Core
{
    public class GameClock
    {
        private const int ActionCountPerMove = 3;
        private readonly List<Guid> _players;
        private int _moveNumber = 1;
        private int _remainingActions = 3;

        public Guid ActingPlayerGuid => _players[_moveNumber%(_players.Count)];

        public bool ShouldCheckForWin => _moveNumber % _players.Count == 1;

        public GameClock(List<Guid> players)
        {
            _players = players;
        }

        public void Tick(int actions = 1)
        {
            if (_remainingActions < actions)
            {
                throw new ArgumentException("You don't have enough actions");
            }
            
            _remainingActions -= actions;

            if (_remainingActions == 0)
            {
                _moveNumber++;
                _remainingActions = 3;
            }
        }
    }
}