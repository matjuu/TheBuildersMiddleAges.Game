using System;
using System.Linq;
using Microsoft.AspNet.Mvc.Filters;
using TheBuildersMiddleAges.Game.Actions;
using TheBuildersMiddleAges.Game.Infrastructure;

namespace TheBuildersMiddleAges.Game.Host.Flters
{
    public class GameFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            ActionRequest request = (ActionRequest) actionContext.ActionArguments.Values.ToList().FirstOrDefault();
            if (request == null) return;

            Core.Game gameInstance;

            if (!GameContainer.Instance.TryGetGame(request, out gameInstance))
            {
                throw new Exception("Game with given Guid does not exist!");
            }
            if (gameInstance.GameClock.GetActingPlayerGuid() != request.PlayerGuid)
            {
                throw new Exception("It's not your turn!");
            }
        }
    }
}