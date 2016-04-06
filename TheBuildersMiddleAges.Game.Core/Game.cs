using System;
using System.Collections.Generic;

namespace TheBuildersMiddleAges.Game.Core
{
    public class Game
    {
        public Dictionary<Guid, Player> Players { get; private set; } = new Dictionary<Guid, Player>();
        public GameBoard GameBoard { get; private set; } = new GameBoard();
        private Deck<Worker> _workersDeck = DeckFactory.WorkerDeck();
        private Deck<Building> _buildingsDeck = DeckFactory.BuildingDeck();
        public GameState State { get; private set; }

        public Game(){}

        public Game(IEnumerable<Guid> playerGuids)
        {
            foreach (var playerGuid in playerGuids)
            {
                Players.Add(playerGuid, new Player());
            }
            
            InitializeGameboard();
        }

        public void TakeWorker(Guid playerGuid, int workerId)
        {
            if (Players.ContainsKey(playerGuid))
            {
                Player player;
                Players.TryGetValue(playerGuid, out player);

                var worker = GameBoard.TakeWorker(workerId);

                player.HireWorker(worker);

                GameBoard.Add(_workersDeck.Draw());
            }
        }

        public void TakeBuilding(Guid playerGuid, int buildingId)
        {
            if (Players.ContainsKey(playerGuid))
            {
                Player player;
                Players.TryGetValue(playerGuid, out player);

                var building = GameBoard.TakeBuilding(buildingId);

                player.TakeBuilding(building);

                GameBoard.Add(_buildingsDeck.Draw());
            }
        }

        public void AssignWorkerToBuilding(Guid playerGuid, int workerId, int buildingId)
        {
            if (Players.ContainsKey(playerGuid))
            {
                Player player;
                Players.TryGetValue(playerGuid, out player);

                player.AssignWorkerToBuilding(workerId, buildingId);
            }
        }

        private void InitializeGameboard()
        {
            for (var i = 0; i < 5; i++)
            {
                GameBoard.Add(_workersDeck.Draw());
                GameBoard.Add(_buildingsDeck.Draw());
            }
        }
    }
}
