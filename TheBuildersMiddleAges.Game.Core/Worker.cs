namespace TheBuildersMiddleAges.Game.Core
{
    public class Worker : IBuild, ICard
    {
        public int Id { get; set; }
        public Resources ProducedResources { get; set; }
    }
}