using TheBuildersMiddleAges.Game.Infrastructure;

namespace TheBuildersMiddleAges.Game.Actions.Actions
{
    public class SellMoveAction : ActionBase<ActionResponseBase>
    {
        public override ActionResponseBase Do(ActionRequest request)
        {
            Game = GameContainer.Instance.GetGame(request.GameGuid);
            var player = TryGetPlayer(request.PlayerGuid);
            bool success;
            if (Game.GameClock.Tick())
            {
                player.SellMove();
                success = true;
            }
            else
            {
                success = false;
            }

            return new BasicActionResponse {Success = success};
        }
    }
}
