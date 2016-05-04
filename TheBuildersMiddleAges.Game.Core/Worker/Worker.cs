namespace TheBuildersMiddleAges.Game.Core
{
    public class Worker : IBuild, ICard
    {
        public int Id { get; set; }
        public Resources ProducedResources { get; set; }
        public int Cost { get; set; }
        public WorkerState State { get; set; }

        public Worker(int id, Resources producedResources)
        {
            Id = id;
            ProducedResources = producedResources;
        }
    }
}