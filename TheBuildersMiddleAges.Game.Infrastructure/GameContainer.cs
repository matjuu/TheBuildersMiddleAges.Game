using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TheBuildersMiddleAges.Game.Core;

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

        public Core.Game GetGame(Guid gameGuid)
        {
            if(_games.ContainsKey(gameGuid) == false) throw new Exception("No such game exists.");

            Core.Game gameInstance;
            _games.TryGetValue(gameGuid, out gameInstance);

            return gameInstance;
        }

        //TODO: Run this in a separate thread every few minutes to clean up game container (also potentially move this elsewhere)
        public void RemoveFinishedGames()
        {
            foreach (var game in _games)
            {
                if (game.Value.State == GameState.Over)
                {
                    _games.Remove(game.Key);
                }
            }
        }
    }
}
