using System.Collections.Generic;
using System.Linq;

namespace TheBuildersMiddleAges.Game.Core
{
    public class Deck<T> where T : ICard
    {
        private readonly Queue<T> _cards;

        public Deck(IEnumerable<T> cards)
        {
            _cards = new Queue<T>(Shuffle(cards));
        }

        public T Draw()
        {
            var card = _cards.Dequeue();

            return card;
        }

        public T GetTopCard()
        {
            var card = _cards.Peek();

            return card;
        }

        private IEnumerable<T> Shuffle(IEnumerable<T> cards)
        {
            var query = cards.Select(x => new
            {
                Index = System.Guid.NewGuid(),
                Value = x
            })
                .OrderBy(p => p.Index)
                .Select(p => p.Value);

            return query;

        }
    }
}