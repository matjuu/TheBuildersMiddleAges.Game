using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
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
        public dynamic GetGameState()
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
        public string TakeWorker()
        {
            return "Worker has been successfully taken.";
        }

        [HttpPost]
        [Route("api/building/take")]
        public string TakeBuilding()
        {
            return "Building has been successfully taken";

        }

        [HttpPost]
        [Route("api/worker/assign")]
        public string AssignWorker()
        {
            return "Worker has been successfully assigned.";
        }
    }
}
