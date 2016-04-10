using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using TheBuildersMiddleAges.Game.Actions;
using TheBuildersMiddleAges.Game.Actions.Actions;
using TheBuildersMiddleAges.Game.Host.Contracts;
using TheBuildersMiddleAges.Game.Infrastructure;

namespace TheBuildersMiddleAges.Game.Host.Controllers
{
    public class GameController : Controller
    {
        private readonly ActionHandler _handler = new ActionHandler();
        private Core.Game _game;

        [HttpPost]
        [Route("api/game/create")]
        public dynamic CreateGameInstance()
        {
            //TODO: This method should be called by the lobby service when multiplayer is implemented
            List<Guid> players = new List<Guid> { Guid.NewGuid() };

            var gameGuid = GameContainer.Instance.CreateGame(players);

            return new
            {
                gameGuid,
                playerGuid = players.First()
            };
        }

        [HttpPost]
        [Route("api/game/state")]
        public Core.Game GetGameState([FromBody] BasicRequest request)
        {
            //TODO: Create or use (?) a mapper to transform Game into GameDto that can be returned (since JSSerializer lacks functionality)
            return GameContainer.Instance.GetGame(request.GameGuid);
        }

        [HttpPost]
        [Route("api/game/worker/take")]
        public ActionResult TakeWorker([FromBody] ActionRequest request)
        {
            ActionResponse response = _handler.HandleAction(request, new TakeWorkerCardAction(_game));

            return Json(new { response });
        }

        [HttpPost]
        [Route("api/game/building/take")]
        public ActionResponse TakeBuilding([FromBody] ActionRequest request)
        {
            ActionResponse response = _handler.HandleAction(request, new TakeBuildingCardAction(GameContainer.Instance.GetGame(request.GameGuid)));

            return response;
        }

        [HttpPost]
        [Route("api/game/worker/assign")]
        public string AssignWorker([FromBody] AssignWorkerRequest request)
        {
            var gameInstance = GameContainer.Instance.GetGame(request.GameGuid);

            if (request.PlayerGuid != null) gameInstance.AssignWorkerToBuilding(request.PlayerGuid.Value, request.workerId, request.buildingId);

            return "Worker has been successfully assigned.";
        }
    }
}
