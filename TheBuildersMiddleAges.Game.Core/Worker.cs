namespace TheBuildersMiddleAges.Game.Core
{
    public class Worker : IBuild, ICard
    {
        public Resources ProducedResources { get; set; }
        public int Id { get; set; }
    }
}