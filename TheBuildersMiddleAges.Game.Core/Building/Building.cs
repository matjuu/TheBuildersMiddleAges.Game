using System.Collections.Generic;

namespace TheBuildersMiddleAges.Game.Core.Building
{
    public class Building : ICard
    {
        public List<Worker> AssignedWorkers { get; set; } = new List<Worker>();

        public int Id { get; private set; }
        private Resources LackingResources { get; set; }
        public Reward Reward { get; private set; }
        public BuildingState State => DetermineState();

        public Building(int id, Resources requirements, Reward reward)
        {
            Id = id;
            Reward = reward;
            LackingResources = requirements;
        }

        public void AssignWorker(Worker worker)
        {
            AssignedWorkers.Add(worker);
            LackingResources -= worker.ProducedResources;
        }

        private BuildingState DetermineState()
        {
            if (AssignedWorkers.Count == 0) return BuildingState.Idle;

            return LackingResources.NothingLeft() ? BuildingState.Completed : BuildingState.InProgress;
        }
    }
}