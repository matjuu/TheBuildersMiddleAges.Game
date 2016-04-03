using System;
using System.Collections.Generic;

namespace TheBuildersMiddleAges.Game.Core
{
    public class Game
    {
        private Dictionary<Guid, Player> _players = new Dictionary<Guid, Player>();
        private GameBoard _gameBoard = new GameBoard();
        private Deck<Worker> _workersDeck = DeckFactory.WorkerDeck();
        private Deck<Building> _buildingsDeck = DeckFactory.BuildingDeck();
        private GameState _gameState;

        public Game(){}

        public Game(IEnumerable<Guid> playerGuids)
        {
            foreach (var playerGuid in playerGuids)
            {
                _players.Add(playerGuid, new Player());
            }
            
            InitializeGameboard();
        }

        public void TakeWorker(Guid playerGuid, int workerId)
        {
            if (_players.ContainsKey(playerGuid))
            {
                Player player;
                _players.TryGetValue(playerGuid, out player);

                var worker = _gameBoard.TakeWorker(workerId);

                player.HireWorker(worker);

                _gameBoard.Add(_workersDeck.Draw());
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

                _gameBoard.Add(_buildingsDeck.Draw());
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

        private void InitializeGameboard()
        {
            for (var i = 0; i < 5; i++)
            {
                _gameBoard.Add(_workersDeck.Draw());
                _gameBoard.Add(_buildingsDeck.Draw());
            }
        }
    }
}
