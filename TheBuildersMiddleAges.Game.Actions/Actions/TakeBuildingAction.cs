using TheBuildersMiddleAges.Game.Core;
using TheBuildersMiddleAges.Game.Core.Building;

namespace TheBuildersMiddleAges.Game.Actions.Actions
{
    public class TakeBuildingAction : ActionBase<TakeCardActionResponse>
    {
        public TakeBuildingAction(Core.Game game)
        {
            Game = game;
        }

        public override TakeCardActionResponse Do(ActionRequest request)
        {
            if (Game.GameClock.Tick())
            {
                Player player = TryGetPlayer(request.PlayerGuid);
                Building building = Game.TakeBuilding(request.BuildingId);

                player.TakeBuilding(building);
                int newCard = Game.DrawBuilding();
                int topCard = Game.GameBoard.TopBuilding.Id;

                TakeCardActionResponse response = new TakeCardActionResponse
                {
                    Success = true,
                    NewCard = newCard,
                    TopCard = topCard
                };

                return response;
            }
            else
            {
                Player player = TryGetPlayer(request.PlayerGuid);
                int newCard = Game.GameBoard.TopBuilding.Id;
                int topCard = Game.GameBoard.TopBuilding.Id;

                TakeCardActionResponse response = new TakeCardActionResponse
                {
                    Success = false,
                    NewCard = newCard,
                    TopCard = topCard
                };

                return response;
            }
        }
    }
}