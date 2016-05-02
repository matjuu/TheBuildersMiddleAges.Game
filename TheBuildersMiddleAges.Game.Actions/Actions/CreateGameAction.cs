using System;
using System.Collections.Generic;
using System.Linq;
using TheBuildersMiddleAges.Game.Infrastructure;

namespace TheBuildersMiddleAges.Game.Actions.Actions
{
    public class CreateGameAction: ActionBase<CreateGameActionResponse>
    {
        public List<Guid> Players;
        public Guid NewGame;

        public CreateGameAction()
        {
            Players = new List<Guid> {Guid.NewGuid()};
            NewGame = GameContainer.Instance.CreateGame(Players);
        }

        public override CreateGameActionResponse Do(ActionRequest request)
        {

            CreateGameActionResponse response = new CreateGameActionResponse
            {
                gameGuid = NewGame,
                playerGuid = Players.First(),
                Success = true
            };

            return response;
        }
    }
}
