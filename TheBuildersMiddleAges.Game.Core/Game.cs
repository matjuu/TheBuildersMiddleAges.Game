using System;
using System.Collections.Generic;

namespace TheBuildersMiddleAges.Game.Core
{
    public class Game
    {
        private Dictionary<Guid, Player> _players;
        private GameBoard _gameBoard;
        private Deck _workersDeck = new WorkersDeck();
        private Deck _buildings = new BuildingsDeck();
        private GameState _gameState;
    }
}
