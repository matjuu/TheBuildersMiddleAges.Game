namespace TheBuildersMiddleAges.Game.Host.Contracts
{
    public class AssignWorkerRequest : GameRequestBase
    {
        public int workerId { get; set; }
        public int buildingId { get; set; }
    }
}