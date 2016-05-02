﻿using TheBuildersMiddleAges.Game.Core;

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
            Player player = TryGetPlayer(request.PlayerGuid);
            Building building = Game.TakeBuilding(request.BuildingId);

            player.TakeBuilding(building);
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