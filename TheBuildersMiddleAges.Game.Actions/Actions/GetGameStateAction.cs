using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBuildersMiddleAges.Game.Actions.Actions
{
    public class GetGameStateAction : ActionBase<GetGameStateActionResponse>
    {
        public Core.Game CurrentGame;
        public GetGameStateAction(Core.Game game )
        {
            CurrentGame = game;
        }

        public override GetGameStateActionResponse Do(ActionRequest request)
        {
            GetGameStateActionResponse response = new GetGameStateActionResponse
            {
                Game = CurrentGame,
                Success = true
            };

            return response;
        }
    }
}
