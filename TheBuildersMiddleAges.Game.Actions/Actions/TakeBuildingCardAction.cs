using TheBuildersMiddleAges.Game.Core;

namespace TheBuildersMiddleAges.Game.Actions.Actions
{
    public class TakeBuildingCardAction : CardAction
    {
        public TakeBuildingCardAction(Core.Game game)
        {
            Game = game;
        }

        public override ActionResponse Do(ActionRequest request)
        {
            Player player = TryGetPlayer(request.PlayerGuid);
            Building building = Game.TakeBuilding(request.WorkerId);

            player.TakeBuilding(building);
            int newCard = Game.DrawBuilding();

            ActionResponse response = new ActionResponse
            {
                Success = true,
                NewCard = newCard
            };

            return response;
        }
    }
}