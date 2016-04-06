using System;
using System.Collections.Generic;
using System.Linq;

namespace TheBuildersMiddleAges.Game.Core
{
    //TODO: Consider refactoring to implement Command pattern to easily segregate move logic from validation (?)
    public class Game
    {
        public Dictionary<Guid, Player> Players { get; private set; } = new Dictionary<Guid, Player>();
        public GameBoard GameBoard { get; private set; } = new GameBoard();
        public GameState State { get; private set; }

        private Deck<Worker> _workersDeck = DeckFactory.WorkerDeck();
        private Deck<Building> _buildingsDeck = DeckFactory.BuildingDeck();
        private GameClock _gameClock;


        public Game(IEnumerable<Guid> playerGuids)
        {
            _gameClock = new GameClock(playerGuids.ToArray());

            foreach (var playerGuid in playerGuids)
            {
                Players.Add(playerGuid, new Player());
            }
            
            InitializeGameboard();
        }

        public void TakeWorker(Guid playerGuid, int workerId)
        {
            if (Players.ContainsKey(playerGuid) == false) throw new Exception("Unauthorized");
            if (_gameClock.getActingPlayerGuid() != playerGuid) throw new Exception("Not the player's turn yet");

            Player player;
            Players.TryGetValue(playerGuid, out player);

            var worker = GameBoard.TakeWorker(workerId);

            player.HireWorker(worker);

            GameBoard.Add(_workersDeck.Draw());

            CheckIfGameOver();
        }

        public void TakeBuilding(Guid playerGuid, int buildingId)
        {
            if (Players.ContainsKey(playerGuid) == false) throw new Exception("Unauthorized");
            if (_gameClock.getActingPlayerGuid() != playerGuid) throw new Exception("Not the player's turn yet");

            Player player;
            Players.TryGetValue(playerGuid, out player);
     
            var building = GameBoard.TakeBuilding(buildingId);
            player.TakeBuilding(building);
            GameBoard.Add(_buildingsDeck.Draw());
            CheckIfGameOver();
        }

        public void AssignWorkerToBuilding(Guid playerGuid, int workerId, int buildingId)
        {
            if (Players.ContainsKey(playerGuid) == false) throw new Exception("Unauthorized");
            if (_gameClock.getActingPlayerGuid() != playerGuid) throw new Exception("Not the player's turn yet");

            Player player;
            Players.TryGetValue(playerGuid, out player);
            player.AssignWorkerToBuilding(workerId, buildingId);

            CheckIfGameOver();
        }

        private void InitializeGameboard()
        {
            for (var i = 0; i < 5; i++)
            {
                GameBoard.Add(_workersDeck.Draw());
                GameBoard.Add(_buildingsDeck.Draw());
            }
        }

        private void CheckIfGameOver()
        {
            if (Players.Any(x => x.Value.VictoryPoints >= 17))
            {
                State = GameState.Over;
            }
        }
    }
}
