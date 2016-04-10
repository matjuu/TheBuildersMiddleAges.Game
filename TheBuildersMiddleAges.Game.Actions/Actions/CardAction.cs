using System;
using TheBuildersMiddleAges.Game.Core;

namespace TheBuildersMiddleAges.Game.Actions.Actions
{
    public abstract class CardAction
    {
        protected Core.Game Game;
        public abstract ActionResponse Do(ActionRequest request);

        protected Player TryGetPlayer(Guid playerGuid)
        {
            if (Game.Players.ContainsKey(playerGuid) == false) throw new Exception("Unauthorized");
            if (Game.GameClock.GetActingPlayerGuid() != playerGuid) throw new Exception("Not the player's turn yet");

            return Game.Players[playerGuid];
        }
    }
}