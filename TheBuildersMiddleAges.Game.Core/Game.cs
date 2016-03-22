using System;
using System.Collections.Generic;

namespace TheBuildersMiddleAges.Game.Core
{
    public class Game
    {
        private Dictionary<Guid, Player> _players = new Dictionary<Guid, Player>();
        private GameBoard _gameBoard = new GameBoard();
        private Deck<Worker> _workersDeck = new Deck<Worker>(new List<Worker>());
        private Deck<Building> _buildingsDeck = new Deck<Building>(new List<Building>());
        private GameState _gameState;

        public Game(){}

        public Game(IEnumerable<Guid> playerGuids)
        {
            foreach (var playerGuid in playerGuids)
            {
                _players.Add(playerGuid, new Player());
            }

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

        public void AssignWorkerToBuilding(Guid playerGuid, int workerId, int buildingId)
        {
            if (_players.ContainsKey(playerGuid))
            {
                Player player;
                _players.TryGetValue(playerGuid, out player);

                player.AssignJob(workerId, buildingId);
            }
        }

        private void PopulateGameboard()
        {
        }
    }
}
