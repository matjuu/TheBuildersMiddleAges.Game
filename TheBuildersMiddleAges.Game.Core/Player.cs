using System;
using System.Collections.Generic;
using System.Linq;

namespace TheBuildersMiddleAges.Game.Core
{
    public class Player
    {
        public List<Worker> Workers { get; private set; } = new List<Worker>();
        public List<Building> Buildings { get; private set; } = new List<Building>();

        public void HireWorker(Worker worker)
        {
            Workers.Add(worker);
        }

        public void TakeBuilding(Building building)
        {
            Buildings.Add(building);
        }

        public void AssignWorkerToBuilding(int workerId, int buildingId)
        {
            var worker = Workers.First(wrkr => wrkr.Id == workerId);
            var building = Buildings.First(bldng => bldng.Id == buildingId);

            if(worker == null) throw new Exception("No worker with specified ID was found.");
            if(building == null) throw new Exception("No building with specified ID was found.");

            building.AssignWorker(worker);
        }
    }
}