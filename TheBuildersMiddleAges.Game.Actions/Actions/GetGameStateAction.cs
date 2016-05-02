using TheBuildersMiddleAges.Game.Infrastructure;

namespace TheBuildersMiddleAges.Game.Actions.Actions
{
    public class GetGameStateAction : ActionBase<GetGameStateActionResponse>
    {
        public override GetGameStateActionResponse Do(ActionRequest request)
        {
            Core.Game currentGame = GameContainer.Instance.GetGame(request.GameGuid);
            GetGameStateActionResponse response = new GetGameStateActionResponse
            {
                Game = currentGame,
                Success = true
            };

            return response;
        }
    }
}
