using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambling
{
    class Deck
    {
        const int MAXVALUES = 13;
        const int MAXSUITS = 4;
        const int MAXCARDS = MAXVALUES * MAXSUITS;

        List<Card> cards = null;

        public Deck()
        {
            cards = new List<Card>(MAXCARDS);

            for (int i = 0; i < MAXVALUES; i++)
            {
                for (int j = 0; j < MAXSUITS; j++)
                {
                    cards.Add(new Card((Values)i, (Suits)j));
                }
            }
        }

        public void Shuffle()
        {
            Random rand = new Random();

            for (int i = cards.Count - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                // обменять значения data[j] и data[i]
                Card temp = cards[j];
                cards[j] = cards[i];
                cards[i] = temp;
            }
        }

        public void ShowInOrder()
        {
            foreach (Card card in cards)
            {
                Console.WriteLine(card);
            }
        }

        public void RemoveTopCard()
        {
            cards.RemoveAt(cards.Count - 1);
        }

        public Card getLastCard()
        {
            return cards[cards.Count - 1];
        }
    }
}
