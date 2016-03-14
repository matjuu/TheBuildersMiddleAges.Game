using System.Collections.Generic;

namespace TheBuildersMiddleAges.Game.Core
{
    public class Building : ICard
    {
        private List<Worker> _assignedWorkers = new List<Worker>();
        public int Id { get; set; }
        public Reward Reward { get; set; } = new Reward();

        public BuildingState State { get; private set; }
    

        public void AssignWorker(Worker worker)
        {
            _assignedWorkers.Add(worker);
        }

    }

    public enum BuildingState
    {
        Idle = 0,
        InProgress = 1,
        Completed = 0
    }
}