using System;
using System.Collections.Generic;
using System.Linq;

namespace TheBuildersMiddleAges.Game.Core
{
    public class Player
    {
        public List<Worker> Workers { get; private set; } = new List<Worker>();
        public List<Building.Building> Buildings { get; private set; } = new List<Building.Building>();
        public List<Building.Building> CompletedBuildings { get; private set; } = new List<Building.Building>();
        public int VictoryPoints { get; private set; }
        public int Coins { get; private set; } = 20;

        public void HireWorker(Worker worker)
        {
            Workers.Add(worker);
        }

        public void TakeBuilding(Building.Building building)
        {
            Buildings.Add(building);
        }

        public BuildingState AssignWorkerToBuilding(int workerId, int buildingId)
        {
            var worker = Workers.FirstOrDefault(wrkr => wrkr.Id == workerId);
            var building = Buildings.FirstOrDefault(bldng => bldng.Id == buildingId);

            if(worker == null) throw new Exception("No worker with specified ID was found.");
            if(building == null) throw new Exception("No building with specified ID was found.");
                //throw new Exception("Not enough coins.");
            
            Coins -= worker.Cost;
            building.AssignWorker(worker);
            worker.State = WorkerState.Working;

            if (building.State == BuildingState.Completed)
            {
                MoveBuildingToCompleted(building);
                ReleaseWorkers(building);
                VictoryPoints += building.Reward.VictoryPoints;
                Coins += building.Reward.Coins;

                return BuildingState.Completed;
            }

            return BuildingState.InProgress;
        }

        public bool HasEnoughCoins(int workerId)
        {
            var worker = Workers.FirstOrDefault(wrkr => wrkr.Id == workerId);
            if (worker != null && worker.Cost > Coins)
            {
                return false;
            }
            return true;
        }

        public void SellMove()
        {
            Coins++;
        }

        public void BuyMove()
        {
            Coins += 5;
        }

        private void ReleaseWorkers(Building.Building building)
        {
            var workerIds = building.AssignedWorkers.Select(x => x.Id);
            var workers = Workers.Where(x => workerIds.Contains(x.Id));
            foreach (var worker in workers)
            {
                worker.State = WorkerState.Idle;
            }
        }

        private void MoveBuildingToCompleted(Building.Building building)
        {
            CompletedBuildings.Add(building);
            Buildings.Remove(building);
        }
    }
} 