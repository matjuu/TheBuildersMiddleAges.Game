using System;
using System.Collections.Generic;
using System.Linq;

namespace TheBuildersMiddleAges.Game.Core
{
    public class GameBoard
    {
        private List<Worker> _workers = new List<Worker>();
        private List<Building> _buildings = new List<Building>();

        public Worker TakeWorker(int workerId)
        {
            var worker =_workers.First(wrkr => wrkr.Id == workerId);

            if (worker == null)
            {
                throw new Exception("No worker with specified ID exists on board");
            }

            _workers.Remove(worker);
                
            return worker;
        }

        public Building TakeBuilding(int buildingId)
        {
            var building = _buildings.First(bldngs => bldngs.Id == buildingId);

            if (building == null)
            {
                throw new Exception("No building with specified ID exists on board");
            }

            _buildings.Remove(building);

            return building;
        }
    }
}