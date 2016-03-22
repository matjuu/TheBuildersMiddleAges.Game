using System;
using System.Collections.Generic;

namespace TheBuildersMiddleAges.Game.Infrastructure
{
    public class GameContainer
    {
        private Dictionary<Guid, Core.Game> _games = new Dictionary<Guid, Core.Game>();
        public static GameContainer Instance { get; } = new GameContainer();

        public Guid CreateGame(IEnumerable<Guid> players)
        {
            var gameGuid = Guid.NewGuid();

            _games.Add(gameGuid, new Core.Game(players));


            return gameGuid;
        }

        public void RemoveGame(Guid gameGuid)
        {
            _games.Remove(gameGuid);
        }
    }
}
