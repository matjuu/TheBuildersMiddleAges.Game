using System.Collections.Generic;

namespace TheBuildersMiddleAges.Game.Core
{
    public static class DeckFactory
    {
        public static Deck<Building> BuildingDeck()
        {
            var cards = new List<Building>();

            for (var id = 1; id <= 30; id++)
            {
                cards.Add(new Building(id, new Resources(1, 1, 2 , 4), new Reward(5, 6)));
            }

            return new Deck<Building>(cards);
        }

        public static Deck<Worker> WorkerDeck()
        {
            var cards = new List<Worker>();

            for (var id = 1; id <= 30; id++)
            {
                cards.Add(new Worker(id, new Resources(1, 1, 1 , 1)));
            }

            return new Deck<Worker>(cards);
        }
    }
}
