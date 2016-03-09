using System;
using System.Collections.Generic;
using System.Linq;

namespace TheBuildersMiddleAges.Game.Core
{
    public class GameBoard
    {
        private List<Worker> _workers = new List<Worker>(); 

        public Worker TakeWorker(int workerId)
        {
            var worker =_workers.First(wrkr => wrkr.Id == workerId);

            if (worker == null)
            {
                throw new Exception("No worker with specified ID exists on board");
            }

            return worker;
        }
    }
}