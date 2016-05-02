using System;
using System.Collections.Generic;
using System.Linq;
using TheBuildersMiddleAges.Game.Infrastructure;

namespace TheBuildersMiddleAges.Game.Actions.Actions
{
    public class CreateGameAction: ActionBase<CreateGameActionResponse>
    { 
        public override CreateGameActionResponse Do(ActionRequest request)
        {
            List<Guid> players = new List<Guid> {Guid.NewGuid()};
            Guid newGame = GameContainer.Instance.CreateGame(players);
            CreateGameActionResponse response = new CreateGameActionResponse
            {
                gameGuid = newGame,
                playerGuid = players.First(),
                Success = true
            };

            return response;
        }
    }
}
