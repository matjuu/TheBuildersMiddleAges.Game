using System;
using System.Collections.Generic;

namespace TheBuildersMiddleAges.Game.Infrastructure
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public static class GameContainer
    {
        private static Dictionary<Guid, Core.Game> _games = new Dictionary<Guid, Core.Game>();

        public static Guid CreateGame()
        {
            var gameGuid = Guid.NewGuid();

            _games.Add(gameGuid, new Core.Game());

            return gameGuid;
        }

        public static void RemoveGame(Guid gameGuid)
        {
            _games.Remove(gameGuid);
        }
    }
}
