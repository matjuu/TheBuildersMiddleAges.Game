using TheBuildersMiddleAges.Game.Infrastructure;

namespace TheBuildersMiddleAges.Game.Actions.Actions
{
    public class BuyMoveAction : ActionBase<ActionResponseBase>
    {
        public override ActionResponseBase Do(ActionRequest request)
        {
            Game = GameContainer.Instance.GetGame(request.GameGuid);
            var player = TryGetPlayer(request.PlayerGuid);

            player.BuyMove();
            Game.GameClock.Tick();

            return new BasicActionResponse { Success = true };
        }
    }
}