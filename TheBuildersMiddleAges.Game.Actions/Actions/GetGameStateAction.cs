using TheBuildersMiddleAges.Game.Infrastructure;
using TheBuildersMiddleAges.Game.Infrastructure.Models.DTO;
using TheBuildersMiddleAges.Game.Utils.Mappers;

namespace TheBuildersMiddleAges.Game.Actions.Actions
{
    public class GetGameStateAction : ActionBase<GetGameStateActionResponse>
    {
        public override GetGameStateActionResponse Do(ActionRequest request)
        {
            Core.Game currentGame = GameContainer.Instance.GetGame(request.GameGuid);
            GameStateMapper mapper = new GameStateMapper();
            GameDto gameDto = mapper.Map(currentGame);
                       
            GetGameStateActionResponse response = new GetGameStateActionResponse
            {
                Game = gameDto,
                Success = true
            };

            return response;
        }
    }
}
