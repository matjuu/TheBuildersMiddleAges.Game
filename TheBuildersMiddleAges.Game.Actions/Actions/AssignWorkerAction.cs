using System.Threading;
using TheBuildersMiddleAges.Game.Core;

namespace TheBuildersMiddleAges.Game.Actions.Actions
{
    public class AssignWorkerAction : ActionBase<AssignWorkerActionResponse>
    {
        public AssignWorkerAction(Core.Game game)
        {
            Game = game;
        }

        public override AssignWorkerActionResponse Do(ActionRequest request)
        {
            
            Player player = TryGetPlayer(request.PlayerGuid);
            int workerId = request.WorkerId;
            int buildingId = request.BuildingId;
            bool success;
            bool enoughActions = Game.GameClock.Tick();
            BuildingState buildingState = BuildingState.InProgress;

            if (player.HasEnoughCoins(workerId) && enoughActions)
            {
                buildingState = player.AssignWorkerToBuilding(workerId, buildingId);
                success = true;
            }
            else if(player.HasEnoughCoins(workerId) && enoughActions == false)
            {
                success = true;
            }
            else
            {
                success = false;
                enoughActions = true;
            }

            AssignWorkerActionResponse response = new AssignWorkerActionResponse
            {
                Success = success,
                BuildingCompleted = buildingState == BuildingState.Completed,
                EnoughActions = enoughActions
            };

            return response;
        }
    }
}