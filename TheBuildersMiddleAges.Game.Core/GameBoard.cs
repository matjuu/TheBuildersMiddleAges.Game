using System;
using System.Collections.Generic;
using System.Linq;

namespace TheBuildersMiddleAges.Game.Core
{
    public class GameBoard
    {
        public List<Worker> Workers { get; private set; } = new List<Worker>();
        public List<Building> Buildings { get; private set; } = new List<Building>();

        public void Add(Worker worker)
        {
            Workers.Add(worker);
        }

        public void Add(Building building)
        {
            Buildings.Add(building);
        }

        public Worker TakeWorker(int workerId)
        {
            var worker =Workers.First(wrkr => wrkr.Id == workerId);

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