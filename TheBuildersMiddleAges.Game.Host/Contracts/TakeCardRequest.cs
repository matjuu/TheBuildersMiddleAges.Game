namespace TheBuildersMiddleAges.Game.Host.Contracts
{
    public class TakeCardRequest : GameRequestBase
    {
        public int cardId { get; set; }
    }
}