namespace TheBuildersMiddleAges.Game.Core
{
    public static class DeckFactory
    {
        public static Deck<Building.Building> BuildingDeck()
        {   
            return Parser.CardsParser.ParseBuildingsDeck();
        }

        public static Deck<Worker> WorkerDeck()
        {
            return Parser.CardsParser.ParseWorkersDeck();
        }
    }
}
