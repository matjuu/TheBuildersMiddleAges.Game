using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBuildersMiddleAges.Game.Infrastructure;

namespace TheBuildersMiddleAges.Game.Actions.Actions
{
    public class StartBuildingAction : ActionBase<ActionResponseBase>
    {
        public override ActionResponseBase Do(ActionRequest request)
    {
        Game = GameContainer.Instance.GetGame(request.GameGuid);
        var player = TryGetPlayer(request.PlayerGuid);

        return new BasicActionResponse { Success = Game.GameClock.Tick() };
    }
   }
}
