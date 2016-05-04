using System;
using System.Collections.Generic;
using System.Linq;

namespace TheBuildersMiddleAges.Game.Core
{
    public class GameBoard
    {
        public List<Worker> Workers { get; set; } = new List<Worker>();
        public List<Building> Buildings { get; set; } = new List<Building>();

        private Deck<Worker> _workersDeck = DeckFactory.WorkerDeck();
        private Deck<Building> _buildingsDeck = DeckFactory.BuildingDeck();

        public Building TopBuilding => _buildingsDeck.GetTopCard();
        public Worker TopWorker => _workersDeck.GetTopCard();

        public int DrawWorker()
        {
            Worker newCard = _workersDeck.Draw();

            Workers.Add(newCard);

            return newCard.Id;
        }

        public int DrawBuilding()
        {
            Building newCard = _buildingsDeck.Draw();

            Buildings.Add(newCard);

            return newCard.Id;
        }

        public void AddWorker()
        {
            Workers.Add(_workersDeck.Draw());
        }

        public void AddBuilding()
        {
            Buildings.Add(_buildingsDeck.Draw());
        }

        public Worker TakeWorker(int workerId)
        {
            var worker = Workers.FirstOrDefault(wrkr => wrkr.Id == workerId);

            if (worker == null)
            {
                throw new Exception("No worker with specified ID exists on board");
            }

            Workers.Remove(worker);
                
            return worker;
        }

        public Building TakeBuilding(int buildingId)
        {
            var building = Buildings.First(bldngs => bldngs.Id == buildingId);

            if (building == null)
            {
                throw new Exception("No building with specified ID exists on board");
            }

            Buildings.Remove(building);

            return building;
        }
    }
}