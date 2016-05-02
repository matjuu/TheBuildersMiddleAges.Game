using System;
using System.Collections.Generic;
using System.Linq;

namespace TheBuildersMiddleAges.Game.Core
{
    public class GameBoard
    {
        private List<Worker> Workers { get; set; } = new List<Worker>();
        private List<Building> Buildings { get; set; } = new List<Building>();

        public void AddWorker(Worker worker)
        {
            Workers.Add(worker);
        }

        public void AddBuilding(Building building)
        {
            Buildings.Add(building);
        }

        public Worker TakeWorker(int workerId)
        {
            var worker = Workers.FirstOrDefault(wrkr => wrkr.Id == workerId);

            if (worker == null)
            {
                throw new Exception("No worker with specified ID exists on board");
            }

            Workers.Remove(worker);
                
            return worker;
        }

        public Building TakeBuilding(int buildingId)
        {
            var building = Buildings.First(bldngs => bldngs.Id == buildingId);

            if (building == null)
            {
                throw new Exception("No building with specified ID exists on board");
            }

            Buildings.Remove(building);

            return building;
        }
    }
}