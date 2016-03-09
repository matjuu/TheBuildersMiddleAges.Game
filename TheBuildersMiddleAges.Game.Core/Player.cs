using System.Collections.Generic;

namespace TheBuildersMiddleAges.Game.Core
{
    public class Player
    {
        private List<Worker> _workers = new List<Worker>();

        public void HireWorker(Worker worker)
        {
            _workers.Add(worker);
        }
    }
}