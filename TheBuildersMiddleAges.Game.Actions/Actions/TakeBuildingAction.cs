using TheBuildersMiddleAges.Game.Core;
using TheBuildersMiddleAges.Game.Infrastructure;

namespace TheBuildersMiddleAges.Game.Actions.Actions
{
    public class TakeBuildingAction : ActionBase<TakeCardActionResponse>
    {
        public override TakeCardActionResponse Do(ActionRequest request)
        {
            Game = GameContainer.Instance.GetGame(request.GameGuid);
            Player player = TryGetPlayer(request.PlayerGuid);
            Building building = Game.TakeBuilding(request.BuildingId);

            player.TakeBuilding(building);
            Game.GameClock.Tick();
            int newCard = Game.DrawBuilding();

            TakeCardActionResponse response = new TakeCardActionResponse
            {
                Success = true,
                NewCard = newCard
            };

            return response;
        }
    }
}