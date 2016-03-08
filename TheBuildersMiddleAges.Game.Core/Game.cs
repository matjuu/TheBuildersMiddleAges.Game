using System;
using System.Collections.Generic;

namespace TheBuildersMiddleAges.Game.Core
{
    public class Game
    {
        private Dictionary<Guid, Player> _players = new Dictionary<Guid, Player>();
        private GameBoard _gameBoard = new GameBoard();
        private Deck<Worker> _workersDeck;
        private Deck<Building> _buildingsDeck;
        private GameState _gameState;

        Game(Guid playerGuid)
        {
            _players.Add(playerGuid, new Player());

            _workersDeck.Shuffle();
            _buildingsDeck.Shuffle();

            PopulateGameboard();
        }

        private void PopulateGameboard()
        {
            //TODO: A method which draws cards and puts them on the Game Board
            throw new NotImplementedException();
        }
    }
}
