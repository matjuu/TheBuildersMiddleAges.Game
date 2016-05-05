using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Primitives;
using TheBuildersMiddleAges.Game.Actions;
using TheBuildersMiddleAges.Game.Actions.Actions;
using TheBuildersMiddleAges.Game.Host.Flters;
using TheBuildersMiddleAges.Game.Infrastructure;

namespace TheBuildersMiddleAges.Game.Host.Controllers
{
    public class GameController : Controller
    {
        private readonly ActionHandler _handler = new ActionHandler();

        [HttpPost]
        [Route("api/game/create")]
        public dynamic CreateGameInstance([FromBody] ActionRequest request)
        {
            //TODO: This method should be called by the lobby service when multiplayer is implemented
            var response =
                _handler.HandleAction<CreateGameAction, CreateGameActionResponse>(request, new CreateGameAction());

            Response.Headers.Add(new KeyValuePair<string, StringValues>("Access-Control-Allow-Origin", "*"));
            return response;
        }

        [HttpPost]
        [Route("api/game/state")]
        public GetGameStateActionResponse GetGameState(ActionRequest request)
        {
            //TODO: Create or use (?) a mapper to transform Game into GameDto that can be returned (since JSSerializer lacks functionality)
            var response =
                _handler.HandleAction<GetGameStateAction, GetGameStateActionResponse>(request, new GetGameStateAction());

            Response.Headers.Add(new KeyValuePair<string, StringValues>("Access-Control-Allow-Origin", "*"));
            return response;
        }

        [HttpPost]
        [GameFilter]
        [Route("api/game/worker/take")]
        public ActionResult TakeWorker(ActionRequest request)
        {
            var response = _handler.HandleAction<TakeWorkerAction, TakeCardActionResponse>(request, new TakeWorkerAction(GameContainer.Instance.GetGame(request.GameGuid)));

            Response.Headers.Add(new KeyValuePair<string, StringValues>("Access-Control-Allow-Origin", "*"));
            return Json(new { response });
        }

        [HttpPost]
        [GameFilter]
        [Route("api/game/building/take")]
        public TakeCardActionResponse TakeBuilding(ActionRequest request)
        {
            TakeCardActionResponse response = _handler.HandleAction<TakeBuildingAction, TakeCardActionResponse>(request, new TakeBuildingAction(GameContainer.Instance.GetGame(request.GameGuid)));

            Response.Headers.Add(new KeyValuePair<string, StringValues>("Access-Control-Allow-Origin", "*"));
            return response;
        }

        [HttpPost]
        [GameFilter]
        [Route("api/game/worker/assign")]
        public ActionResponseBase AssignWorker(ActionRequest request)
        {

            var response = _handler.HandleAction<AssignWorkerAction, ActionResponseBase>
                (request, new AssignWorkerAction(GameContainer.Instance.GetGame(request.GameGuid)));

            Response.Headers.Add(new KeyValuePair<string, StringValues>("Access-Control-Allow-Origin", "*"));
            return response;
        }

        [HttpPost]
        [GameFilter]
        [Route("/api/game/move/sell")]
        public ActionResponseBase SellMove([FromBody] ActionRequest request)
        {
            var response = _handler.HandleAction<SellMoveAction, ActionResponseBase>(request, new SellMoveAction());

            Response.Headers.Add(new KeyValuePair<string, StringValues>("Access-Control-Allow-Origin", "*"));
            return response;
        }

        [HttpPost]
        [GameFilter]
        [Route("/api/game/move/buy")]
        public ActionResponseBase BuyMove([FromBody] ActionRequest request)
        {
            var response = _handler.HandleAction<BuyMoveAction, ActionResponseBase>(request, new BuyMoveAction());

            Response.Headers.Add(new KeyValuePair<string, StringValues>("Access-Control-Allow-Origin", "*"));
            return response;
        }
    }
}
