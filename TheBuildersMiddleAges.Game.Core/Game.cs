using System;
using System.Collections.Generic;

namespace TheBuildersMiddleAges.Game.Core
{
    public class Game
    {
        private Dictionary<Guid, Player> _players;
        private GameBoard _gameBoard;
        private Deck<Worker> _workersDeck;
        private Deck<Building> _buildingsDeck;
        private GameState _gameState;
    }
}
