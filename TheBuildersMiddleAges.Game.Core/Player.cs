using System.Collections.Generic;

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
    }
}