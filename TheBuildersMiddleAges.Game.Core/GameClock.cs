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
        public int RemainingActions = 3;

        public Guid ActingPlayerGuid => _players[_moveNumber%(_players.Count)];

        public bool ShouldCheckForWin => _moveNumber % _players.Count == 1;

        public GameClock(List<Guid> players)
        {
            _players = players;
        }

        public bool Tick(int actions = 1)
        {
            if (RemainingActions < actions)
            {
                return false;
            }
            
            RemainingActions -= actions;
            return true;
        }

        public bool UnTick(int actions = 1)
        {
            RemainingActions += actions;
            return true;
        }

        public void ResetActions()
        {
            RemainingActions = 3;
        }
    }
}