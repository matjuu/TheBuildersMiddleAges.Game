using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBuildersMiddleAges.Game.Actions.Actions
{
    public class CreateGameAction: ActionBase<CreateGameActionResponse>
    {
        public List<Guid> players;
        public Guid NewGame;

        public CreateGameAction(Guid game, List<Guid> players)
        {
            NewGame = game;
            this.players = players;
        }

        public override CreateGameActionResponse Do(ActionRequest request)
        {

            CreateGameActionResponse response = new CreateGameActionResponse
            {
                gameGuid = NewGame,
                playerGuid = players.First(),
                Success = true
            };

            return response;
        }
    }
}
