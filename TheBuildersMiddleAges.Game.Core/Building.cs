using System.Collections.Generic;

namespace TheBuildersMiddleAges.Game.Core
{
    public class Building : ICard
    {
        public List<Worker> AssignedWorkers { get; set; } = new List<Worker>();

        public int Id { get; set; }
        public Resources Requirements { get; set; }
        public Reward Reward { get; set; }
        public BuildingState State => DetermineState();

        public Building(int id,Resources requirements, Reward reward)
        {
            Id = id;
            Reward = reward;
            Requirements = requirements;
        }

        public void AssignWorker(Worker worker)
        {
            AssignedWorkers.Add(worker);
        }

        private BuildingState DetermineState()
        {
            if (AssignedWorkers.Count <= 0) return BuildingState.Idle;

            var completedWork = new Resources(0,0,0,0);
            foreach (var worker in AssignedWorkers)
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