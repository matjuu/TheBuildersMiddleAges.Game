using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBuildersMiddleAges.Game.Infrastructure;

namespace TheBuildersMiddleAges.Game.Actions.Actions
{
 public class EndTurnAction : ActionBase<ActionResponseBase>
    {
        public override ActionResponseBase Do(ActionRequest request)
        {
            Game = GameContainer.Instance.GetGame(request.GameGuid);
            var player = TryGetPlayer(request.PlayerGuid);

            Game.GameClock.ResetActions();

            return new BasicActionResponse { Success = true };
        }
    }
}
