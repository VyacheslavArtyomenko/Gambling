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

        public int BigBlind { get; set; }
        public int SmallBlind { get; set; }
        public int CurrentButtonPosition { get; set; }

        public int CurrentBank { get; set; } = 0;

        public void Initialize()
        {
            players = new List<Player>();
            deck = new Deck();
            deck.Shuffle();
            SmallBlind = BigBlind / 2;
        }

        public Game()
        {
            BigBlind = 100;
            Initialize();
        }

        public Game(int bigBlind)
        {
            BigBlind = bigBlind;
            Initialize();
        }

        public void AddPlayer(string name)
        {
            players.Add(new Player(name));
        }

        public void AddPlayer(string name, int bankroll)
        {
            players.Add(new Player(name, bankroll));
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

        public void ShowPlayersBalance()
        {
            Console.WriteLine("Balance: ");
            foreach (Player player in players)
            {
                player.ShowBalance();
            }
        }

        // TO DO
        public void RandomlySelectButtonPosition()
        {
            Random rand = new Random();

        }

        // TO DO (for all with any position)
        public void PostBlinds()
        {
            players[CurrentButtonPosition + 1].TakeFromBankroll(SmallBlind);
            players[CurrentButtonPosition + 2].TakeFromBankroll(BigBlind);
            CurrentBank = SmallBlind + BigBlind;
        }

        public void PlayRound()
        {
            DealCardsToPlayers();


            // randomly select position
            // PostBlinds();
            // DealFlop();
        }
    }
}

// add history of each round to database