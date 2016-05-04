using Microsoft.AspNet.Mvc;
using TheBuildersMiddleAges.Game.Actions;
using TheBuildersMiddleAges.Game.Actions.Actions;
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
            return response;
        }

        [HttpPost]
        [Route("api/game/state")]
        public GetGameStateActionResponse GetGameState([FromBody] ActionRequest request)
        {
            //TODO: Create or use (?) a mapper to transform Game into GameDto that can be returned (since JSSerializer lacks functionality)
            var response =
                _handler.HandleAction<GetGameStateAction, GetGameStateActionResponse>(request, new GetGameStateAction());
            return response;
        }

        [HttpPost]
        [Route("api/game/worker/take")]
        public ActionResult TakeWorker([FromBody] ActionRequest request)
        {
            var response = _handler.HandleAction<TakeWorkerAction, TakeCardActionResponse>(request, new TakeWorkerAction(GameContainer.Instance.GetGame(request.GameGuid)));

            return Json(new { response });
        }

        [HttpPost]
        [Route("api/game/building/take")]
        public TakeCardActionResponse TakeBuilding([FromBody] ActionRequest request)
        {
            TakeCardActionResponse response = _handler.HandleAction<TakeBuildingAction, TakeCardActionResponse>(request, new TakeBuildingAction(GameContainer.Instance.GetGame(request.GameGuid)));

            return response;
        }

        [HttpPost]
        [Route("api/game/worker/assign")]
        public ActionResponseBase AssignWorker([FromBody] ActionRequest request)
        {

            var response = _handler.HandleAction<AssignWorkerAction, ActionResponseBase>
                (request, new AssignWorkerAction(GameContainer.Instance.GetGame(request.GameGuid)));

            return response;
        }

        [HttpPost]
        [Route("/api/game/move/sell")]
        public ActionResponseBase SellMove([FromBody] ActionRequest request)
        {
            var response = _handler.HandleAction<SellMoveAction, ActionResponseBase>(request, new SellMoveAction());

            return response;
        }

        [HttpPost]
        [Route("/api/game/move/buy")]
        public ActionResponseBase BuyMove([FromBody] ActionRequest request)
        {
            var response = _handler.HandleAction<BuyMoveAction, ActionResponseBase>(request, new BuyMoveAction());

            return response;
        }
    }
}
