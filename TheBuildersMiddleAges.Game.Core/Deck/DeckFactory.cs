namespace TheBuildersMiddleAges.Game.Core
{
    public static class DeckFactory
    {
        public static Deck<Building> BuildingDeck()
        {   
            return Parser.CardsParser.ParseBuildingsDeck();
        }

        public static Deck<Worker> WorkerDeck()
        {
            return Parser.CardsParser.ParseWorkersDeck();
        }
    }
}
