using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace TheBuildersMiddleAges.Game.Core
{
    public class Game
    {
        private Dictionary<Guid, Player> _players = new Dictionary<Guid, Player>();
        private GameBoard _gameBoard = new GameBoard();
        private Deck<Worker> _workersDeck;
        private Deck<Building> _buildingsDeck;
        private GameState _gameState;

        public Game(){}

        public Game(Guid playerGuid)
        {
            _players.Add(playerGuid, new Player());

            _workersDeck.Shuffle();
            _buildingsDeck.Shuffle();
            
            PopulateGameboard();
        }

        public void HireWorker(Guid playerGuid, int workerId)
        {
            if (_players.ContainsKey(playerGuid))
            {
                Player player;
                _players.TryGetValue(playerGuid, out player);

                var worker = _gameBoard.TakeWorker(workerId);

                player.HireWorker(worker);

                PopulateGameboard();
            }
        }

        public void TakeBuilding(Guid playerGuid, int buildingId)
        {
            if (_players.ContainsKey(playerGuid))
            {
                Player player;
                _players.TryGetValue(playerGuid, out player);

                var building = _gameBoard.TakeBuilding(buildingId);

                player.TakeBuilding(building);

                PopulateGameboard();
            }
        }

        private void PopulateGameboard()
        {
            //TODO: A method which draws cards and puts them on the Game Board
            throw new NotImplementedException();
        }
    }
}
