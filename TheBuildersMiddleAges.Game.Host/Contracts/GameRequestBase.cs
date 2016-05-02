using System;

namespace TheBuildersMiddleAges.Game.Host.Contracts
{
    public abstract class GameRequestBase
    {
        public Guid GameGuid { get; set; }
        public Guid? PlayerGuid { get; set; }
    }
}
