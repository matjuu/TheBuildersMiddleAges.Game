namespace TheBuildersMiddleAges.Game.Core
{
    public class Building : ICard
    {
        public int Id { get; set; }
        public Reward Reward { get; set; } = new Reward();
    }
}