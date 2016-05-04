using System;
using System.Collections.Generic;
using System.Linq;

namespace TheBuildersMiddleAges.Game.Core
{
    public class Player
    {
        public List<Worker> Workers { get; private set; } = new List<Worker>();
        public List<Building> Buildings { get; private set; } = new List<Building>();
        public List<Building> CompletedBuildings { get; private set; } = new List<Building>();
        public int VictoryPoints { get; private set; }
        public int Coins { get; private set; } = 20;

        public void HireWorker(Worker worker)
        {
            Workers.Add(worker);
        }

        public void TakeBuilding(Building building)
        {
            //TODO: AddWorker Building costs
            Buildings.Add(building);
        }

        public void AssignWorkerToBuilding(int workerId, int buildingId)
        {
            var worker = Workers.FirstOrDefault(wrkr => wrkr.Id == workerId);
            var building = Buildings.FirstOrDefault(bldng => bldng.Id == buildingId);

            if(worker == null) throw new Exception("No worker with specified ID was found.");
            if(building == null) throw new Exception("No building with specified ID was found.");
            //TODO: AddWorker worker costs

            building.AssignWorker(worker);
            worker.State = WorkerState.Working;

            if (building.State == BuildingState.Completed)
            {
                MoveBuildingToCompleted(building);
                ReleaseWorkers(building);
                VictoryPoints += building.Reward.VictoryPoints;
                Coins += building.Reward.Coins;
            }
        }

        private void ReleaseWorkers(Building building)
        {
            var workerIds = building.AssignedWorkers.Select(x => x.Id);
            var workers = Workers.Where(x => workerIds.Contains(x.Id));
            foreach (var worker in workers)
            {
                worker.State = WorkerState.Idle;
            }
        }

        private void MoveBuildingToCompleted(Building building)
        {
            CompletedBuildings.Add(building);
            Buildings.Remove(building);
        }

        public void SellMove()
        {
            //TODO Implement once player has 3 actions per move
            Coins++;
        }

        public void BuyMove()
        {
            //TODO Implement once player has 3 actions per move
            throw new NotImplementedException();
        }
    }
} 