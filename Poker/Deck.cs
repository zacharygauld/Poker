using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Deck
    {
        public List<Card> CardsInDeck { get; set; }

        public Deck()
        {
            CardsInDeck = new List<Card>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    CardsInDeck.Add(new Card((Card.Suit)i, (Card.Value)j));
                }
            }
        }
    }
}
