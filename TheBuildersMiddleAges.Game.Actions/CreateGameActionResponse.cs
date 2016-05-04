using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBuildersMiddleAges.Game.Actions
{
    public class CreateGameActionResponse : ActionResponseBase
    {
        public Guid gameGuid;
        public Guid playerGuid;
    }
}
