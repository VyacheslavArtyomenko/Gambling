using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambling
{
    class Card
    {
        public Values Value { get; private set; }
        public Suits Suit { get; private set; }

        public Card(Values value, Suits suit)
        {
            this.Value = value;
            this.Suit = suit;
        }

        public override string ToString()
        {
            return string.Format($"{Value} of {Suit}");
        }
    }

    public enum Values { Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace };
    public enum Suits { Hearts, Spades, Diamonds, Clubs };
}
