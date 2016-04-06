using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using TheBuildersMiddleAges.Game.Host.Contracts;
using TheBuildersMiddleAges.Game.Infrastructure;

namespace TheBuildersMiddleAges.Game.Host.Controllers
{
    public class GameController : Controller
    {
        [HttpPost]
        [Route("api/game/create")]
        public dynamic CreateGameInstance()
        {
            //TODO: This method should be called by the lobby service when multiplayer is implemented
            IEnumerable<Guid> players = new List<Guid> {Guid.NewGuid()};

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
            return GameContainer.Instance.GetGame(request.GameGuid);
        }

        [HttpPost]
        [Route("api/game/worker/take")]
        public string TakeWorker([FromBody] TakeCardRequest request)
        {
            var gameInstance = GameContainer.Instance.GetGame(request.GameGuid);

            if (request.PlayerGuid != null) gameInstance.TakeWorker(request.PlayerGuid.Value, request.cardId);

            return "Worker has been successfully taken";
        }

        [HttpPost]
        [Route("api/game/building/take")]
        public string TakeBuilding([FromBody] TakeCardRequest request)
        {
            var gameInstance = GameContainer.Instance.GetGame(request.GameGuid);

            if (request.PlayerGuid != null) gameInstance.TakeBuilding(request.PlayerGuid.Value, request.cardId);

            return "Building has been successfully taken";

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
