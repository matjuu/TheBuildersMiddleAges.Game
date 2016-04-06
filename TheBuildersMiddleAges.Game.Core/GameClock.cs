using System;

namespace TheBuildersMiddleAges.Game.Core
{
    public class GameClock
    {
        private Guid[] _players;
        private int _moveNumber = 1;

        public bool ShouldCheckForWin => _moveNumber%_players.Length == 1;

        public GameClock(Guid[] players)
        {
            _players = players;
        }

        public Guid getActingPlayerGuid()
        {
            int actingPlayerIndex = (_moveNumber - 1)%_players.Length;
            return _players[actingPlayerIndex];
        }
    }
}