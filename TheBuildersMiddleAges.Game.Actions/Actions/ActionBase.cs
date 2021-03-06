﻿using System;
using TheBuildersMiddleAges.Game.Core;

namespace TheBuildersMiddleAges.Game.Actions.Actions
{
    public abstract class ActionBase<TResponse>
        where TResponse : ActionResponseBase
    {
        protected Core.Game Game;
        public abstract TResponse Do(ActionRequest request);

        protected Player TryGetPlayer(Guid playerGuid)
        {
            if (Game.Players.ContainsKey(playerGuid) == false) throw new Exception("Unauthorized");
            if (Game.GameClock.ActingPlayerGuid != playerGuid) throw new Exception("Not the player's turn yet");

            return Game.Players[playerGuid];
        }
    }
}