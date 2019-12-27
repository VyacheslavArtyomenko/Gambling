using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambling
{
    class CheckCombination //: IComparable<Card>
    {
        //List<Card> cards;

        //public CheckCombination()
        //{
        //    cards = new List<Card>();
        //}

        public static bool IsRoyalFlush(List<Card> cards)
        {
            return true;
        }

        public bool IsStraightFlush()
        {
            return true;
        }

        public bool IsQuads()
        {
            return true;
        }

    }

    public enum Combinations { HighCard, Pair, TwoPairs, Set, Straight, Flush, Quads, StraightFlush, RoyalFlush }
}
