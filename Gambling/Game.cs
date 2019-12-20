using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambling
{
    class Game
    {
        List<Player> players = null;
        Deck deck = null;
        Card[] flopTurnRiver = new Card[5];

        public Game()
        {
            players = new List<Player>();
            deck = new Deck();
            deck.Shuffle();
        }

        public void AddPlayer(string name)
        {
            players.Add(new Player(name));
        }

        public void RemoveTopCardFromTheDeck()
        {
            deck.RemoveTopCard();
        }

        public void DealCardsToPlayers()
        {
            for (int i = 0; i < players.Count; i++)
            {
                players[i].FirstCard = deck.getLastCard();
                RemoveTopCardFromTheDeck();
                players[i].SecondCard = deck.getLastCard();
                RemoveTopCardFromTheDeck();
            }
        }

        public void ShowPlayersCards()
        {
            foreach (Player player in players)
            {
                player.ShowHand();
            }
        }

        public void DealFlop()
        {
            RemoveTopCardFromTheDeck();

            flopTurnRiver[0] = deck.getLastCard();
            RemoveTopCardFromTheDeck();
            flopTurnRiver[1] = deck.getLastCard();
            RemoveTopCardFromTheDeck();
            flopTurnRiver[2] = deck.getLastCard();
            RemoveTopCardFromTheDeck();
        }

        public void DealTurn()
        {
            RemoveTopCardFromTheDeck();

            flopTurnRiver[3] = deck.getLastCard();
            RemoveTopCardFromTheDeck();
        }

        public void DealRiver()
        {
            RemoveTopCardFromTheDeck();

            flopTurnRiver[4] = deck.getLastCard();
            RemoveTopCardFromTheDeck();
        }

        public void DealAllStreets()
        {
            DealFlop();
            DealTurn();
            DealRiver();
        }

        public void ShowBoard()
        {
            Console.WriteLine("Board: ");
            for (int i = 0; i < flopTurnRiver.Length; i++)
            {
                if (flopTurnRiver[i] == null)
                    Console.Write("N/A ");
                else
                    Console.Write("{0}, ", flopTurnRiver[i]);
            }
        }
    }
}
