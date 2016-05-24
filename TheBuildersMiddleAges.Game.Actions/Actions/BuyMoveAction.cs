using TheBuildersMiddleAges.Game.Infrastructure;

namespace TheBuildersMiddleAges.Game.Actions.Actions
{
    public class BuyMoveAction : ActionBase<ActionResponseBase>
    {
        public override ActionResponseBase Do(ActionRequest request)
        {
            Game = GameContainer.Instance.GetGame(request.GameGuid);
            var player = TryGetPlayer(request.PlayerGuid);
            bool success;
            if (player.HasEnoughCoinsForAction())
            {
                player.BuyMove();
                Game.GameClock.UnTick();
                success = true;
            }
            else
            {
                success = false;
            }
            

            return new BasicActionResponse { Success = success };
        }
    }
}