using System.Threading;
using TheBuildersMiddleAges.Game.Core;

namespace TheBuildersMiddleAges.Game.Actions.Actions
{
    public class AssignWorkerAction : CardAction
    {
        public AssignWorkerAction(Core.Game game)
        {
            Game = game;
        }

        public override ActionResponse Do(ActionRequest request)
        {
            Player player = TryGetPlayer(request.PlayerGuid);
            int workerId = request.WorkerId;
            int buildingId = request.BuildingId;

            player.AssignWorkerToBuilding(workerId, buildingId);

            ActionResponse response = new ActionResponse
            {
                Success = true
            };

            return response;
        }
    }
}