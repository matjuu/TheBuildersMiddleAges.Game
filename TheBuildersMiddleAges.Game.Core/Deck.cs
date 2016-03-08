using System;
using System.Collections.Generic;

namespace TheBuildersMiddleAges.Game.Core
{
    public class Deck<T> where T : ICard { 
        public Deck(List<T> deck)
        {
            _deck = deck;
        }

        private List<T> _deck;

        public void Shuffle()
        {
            throw new NotImplementedException();
        }
    }
}