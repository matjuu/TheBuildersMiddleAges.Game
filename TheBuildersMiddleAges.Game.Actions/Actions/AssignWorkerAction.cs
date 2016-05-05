using TheBuildersMiddleAges.Game.Core;
using TheBuildersMiddleAges.Game.Infrastructure;

namespace TheBuildersMiddleAges.Game.Actions.Actions
{
    public class AssignWorkerAction : ActionBase<ActionResponseBase>
    {
        public override ActionResponseBase Do(ActionRequest request)
        {
            Game = GameContainer.Instance.GetGame(request.GameGuid);
            Player player = TryGetPlayer(request.PlayerGuid);
            int workerId = request.WorkerId;
            int buildingId = request.BuildingId;

            player.AssignWorkerToBuilding(workerId, buildingId);
            Game.GameClock.Tick();

            TakeCardActionResponse response = new TakeCardActionResponse
            {
                Success = true
            };

            return response;
        }
    }
}