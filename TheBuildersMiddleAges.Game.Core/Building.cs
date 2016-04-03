using System.Collections.Generic;

namespace TheBuildersMiddleAges.Game.Core
{
    public class Building : ICard
    {
        private List<Worker> _assignedWorkers = new List<Worker>();

        public int Id { get; set; }
        public Resources Requirements { get; set; }
        public Reward Reward { get; set; }
        public BuildingState State => DetermineState();

        public Building(int Id,Resources requirements, Reward reward)
        {
            Reward = reward;
            Requirements = requirements;
        }

        public void AssignWorker(Worker worker)
        {
            _assignedWorkers.Add(worker);
        }

        private BuildingState DetermineState()
        {
            if (_assignedWorkers.Count <= 0) return BuildingState.Idle;

            var completedWork = new Resources(0,0,0,0);
            foreach (var worker in _assignedWorkers)
            {
                completedWork.Add(worker.ProducedResources);
            }

            return IsBuildingComplete(completedWork) ? BuildingState.Completed : BuildingState.InProgress;
        }

        private bool IsBuildingComplete(Resources completedWork)
        {
            return Requirements.Stone < completedWork.Stone &&
                   Requirements.Wood < completedWork.Wood &&
                   Requirements.Knowledge < completedWork.Knowledge &&
                   Requirements.Tile < completedWork.Tile;
        }
    }
}