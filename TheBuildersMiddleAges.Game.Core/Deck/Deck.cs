using System;
using System.Collections.Generic;

namespace TheBuildersMiddleAges.Game.Core
{
    public class Deck<T> where T : ICard
    {
        private readonly Queue<T> _cards;

        public Deck(IEnumerable<T> cards)
        {
            _cards = new Queue<T>(cards);
            Shuffle();
        }

        public T Draw()
        {
            var card = _cards.Dequeue();

            return card;
        }

        private void Shuffle()
        {
            //TODO: Implement card shuffling
        }
    }
}