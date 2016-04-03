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

            var roomGuid = GameContainer.Instance.CreateGame(players);

            return new
            {
                roomGuid,
                playerGuid = players.First()
            };
        }

        [HttpPost]
        [Route("api/game/state")]
        public dynamic GetGameState(BasicRequest request)
        {
            return new
            {
                Board = "Dummy board object",
                Players = new dynamic[]
                {
                    new
                    {
                        Guid = Guid.NewGuid()
                    }
                }     
            };
        }

        [HttpPost]
        [Route("api/worker/take")]
        public string TakeWorker(TakeCardRequest request)
        {
            var gameInstance = GameContainer.Instance.GetGame(request.GameGuid);

            if (request.PlayerGuid != null) gameInstance.TakeWorker(request.PlayerGuid.Value, request.cardId);

            return "Worker has been successfully taken";
        }

        [HttpPost]
        [Route("api/building/take")]
        public string TakeBuilding(TakeCardRequest request)
        {
            var gameInstance = GameContainer.Instance.GetGame(request.GameGuid);

            if (request.PlayerGuid != null) gameInstance.TakeBuilding(request.PlayerGuid.Value, request.cardId);

            return "Building has been successfully taken";

        }

        [HttpPost]
        [Route("api/worker/assign")]
        public string AssignWorker(AssignWorkerRequest request)
        {
            var gameInstance = GameContainer.Instance.GetGame(request.GameGuid);

            if (request.PlayerGuid != null) gameInstance.AssignWorkerToBuilding(request.PlayerGuid.Value, request.workerId, request.buildingId);

            return "Worker has been successfully assigned.";
        }
    }
}
