using System;
using System.Collections.Generic;
using System.Linq;

namespace TheBuildersMiddleAges.Game.Core
{
    public class Player
    {
        private List<Worker> _workers = new List<Worker>();
        private List<Building> _buildings = new List<Building>();

        public void HireWorker(Worker worker)
        {
            _workers.Add(worker);
        }

        public void TakeBuilding(Building building)
        {
            _buildings.Add(building);
        }

        public void AssignJob(int workerId, int buildingId)
        {
            var worker = _workers.First(wrkr => wrkr.Id == workerId);
            var building = _buildings.First(bldng => bldng.Id == buildingId);

            if(worker == null) throw new Exception("No worker with specified ID was found.");
            if(building == null) throw new Exception("No building with specified ID was found.");

            building.AssignWorker(worker);
        }
    }
}