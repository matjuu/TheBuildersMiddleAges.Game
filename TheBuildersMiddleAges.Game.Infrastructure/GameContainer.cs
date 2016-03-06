using System;
using System.Collections.Generic;

namespace TheBuildersMiddleAges.Game.Infrastructure
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class GameContainer
    {
        private Dictionary<Guid, Core.Game> _games = new Dictionary<Guid, Core.Game>();
        public static GameContainer Instance { get; } = new GameContainer();

        public Guid CreateGame()
        {
            var gameGuid = Guid.NewGuid();

            _games.Add(gameGuid, new Core.Game());

            return gameGuid;
        }

        public void RemoveGame(Guid gameGuid)
        {
            _games.Remove(gameGuid);
        }
    }
}
