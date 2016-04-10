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
        public readonly GameClock GameClock;

        private Deck<Worker> _workersDeck = DeckFactory.WorkerDeck();
        private Deck<Building> _buildingsDeck = DeckFactory.BuildingDeck();


        public Game(List<Guid> playerGuids)
        {
            GameClock = new GameClock(playerGuids);

            foreach (var playerGuid in playerGuids)
            {
                Players.Add(playerGuid, new Player());
            }
            
            InitializeGameboard();
        }

        public Worker TakeWorker(int workerId)
        {
            return GameBoard.TakeWorker(workerId);
        }

        public int DrawWorker()
        {
            Worker newCard = _workersDeck.Draw();
            GameBoard.AddWorker(newCard);

            return newCard.Id;
        }

        public void TakeBuilding(Guid playerGuid, int buildingId)
        {
            if (Players.ContainsKey(playerGuid) == false) throw new Exception("Unauthorized");
            if (GameClock.GetActingPlayerGuid() != playerGuid) throw new Exception("Not the player's turn yet");

            Player player;
            Players.TryGetValue(playerGuid, out player);
     
            var building = GameBoard.TakeBuilding(buildingId);
            player.TakeBuilding(building);
            GameBoard.AddBuilding(_buildingsDeck.Draw());
            CheckIfGameOver();
        }

        public void AssignWorkerToBuilding(Guid playerGuid, int workerId, int buildingId)
        {
            if (Players.ContainsKey(playerGuid) == false) throw new Exception("Unauthorized");
            if (GameClock.GetActingPlayerGuid() != playerGuid) throw new Exception("Not the player's turn yet");

            Player player;
            Players.TryGetValue(playerGuid, out player);
            player.AssignWorkerToBuilding(workerId, buildingId);

            CheckIfGameOver();
        }

        private void InitializeGameboard()
        {
            for (var i = 0; i < 5; i++)
            {
                GameBoard.AddWorker(_workersDeck.Draw());
                GameBoard.AddBuilding(_buildingsDeck.Draw());
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
