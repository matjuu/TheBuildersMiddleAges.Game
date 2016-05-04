using System.Threading;
using TheBuildersMiddleAges.Game.Core;

namespace TheBuildersMiddleAges.Game.Actions.Actions
{
    public class AssignWorkerAction : ActionBase<ActionResponseBase>
    {
        public AssignWorkerAction(Core.Game game)
        {
            Game = game;
        }

        public override ActionResponseBase Do(ActionRequest request)
        {
            Player player = TryGetPlayer(request.PlayerGuid);
            int workerId = request.WorkerId;
            int buildingId = request.BuildingId;

            player.AssignWorkerToBuilding(workerId, buildingId);

            TakeCardActionResponse response = new TakeCardActionResponse
            {
                Success = true
            };

            return response;
        }
    }
}