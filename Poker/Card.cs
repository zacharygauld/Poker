using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Card
    {
        public enum Suit { Spades, Hearts, Diamonds, Clubs }
        public enum Value { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }

        public Suit CardSuit { get; set; }
        public Value CardValue { get; set; }

        public Card(Suit cardSuit, Value cardValue)
        {
            CardSuit = cardSuit;
            CardValue = cardValue;
        }
    }
}
