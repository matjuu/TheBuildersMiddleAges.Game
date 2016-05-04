using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBuildersMiddleAges.Game.Infrastructure;

namespace TheBuildersMiddleAges.Game.Actions.Actions
{
    public class SellMoveAction : ActionBase<ActionResponseBase>
    {
        public override ActionResponseBase Do(ActionRequest request)
        {
            Game = GameContainer.Instance.GetGame(request.GameGuid);
            var player = TryGetPlayer(request.PlayerGuid);

            player.SellMove();
            Game.GameClock.Tick();

            return new BasicActionResponse {Success = true};
        }
    }
}
