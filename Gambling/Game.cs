using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambling
{
    // public delegate void EventDelegate(int amount);
    enum Round { Preflop, Flop, Turn, River };

    class Game
    {
        List<Player> players = null;
        Deck deck = null;
        Card[] flopTurnRiver = new Card[5];

        //public event EventDelegate MyEvent = null;

        //public void InvokeEvent(int amount)
        //{
        //    if (MyEvent != null)
        //        MyEvent(amount);
        //}

        public int BigBlind { get; set; }
        public int SmallBlind { get; set; }
        public int CurrentButtonPosition { get; set; } = 0;

        public int CurrentBank { get; set; } = 0;

        public int CurrentAmountToCall
        { get; set; } = 0;

        public Round round { get; set; }

        public void Initialize()
        {
            players = new List<Player>();
            deck = new Deck();
            deck.Shuffle();
            SmallBlind = BigBlind / 2;
            CurrentAmountToCall = BigBlind;
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

        public void RandomlySelectButtonPosition()
        {
            Random rand = new Random();
            CurrentButtonPosition = rand.Next(0, players.Count);
        }

        //IMPROVE ALGORITHM
        public void DefinePlayersPosition()
        {
            players[CurrentButtonPosition].Position = PlayersPosition.Button;

            if (CurrentButtonPosition < players.Count - 2)
            {
                players[CurrentButtonPosition + 1].Position = PlayersPosition.SmallBlind;
                players[CurrentButtonPosition + 2].Position = PlayersPosition.BigBlind;
            }

            if (CurrentButtonPosition == players.Count - 2)
            {
                players[CurrentButtonPosition - 1].Position = PlayersPosition.SmallBlind;
                players[0].Position = PlayersPosition.BigBlind;
            }

            if (CurrentButtonPosition == players.Count - 1)
            {
                players[0].Position = PlayersPosition.SmallBlind;
                players[1].Position = PlayersPosition.BigBlind;
            }

        }

        public void PostBlinds()
        {
            for (int i = 0; i < players.Count; i++)
            {
                switch (players[i].Position)
                {
                    case PlayersPosition.SmallBlind:
                        players[i].TakeFromBankroll(SmallBlind);
                        CurrentBank += SmallBlind;
                        break;
                    case PlayersPosition.BigBlind:
                        players[i].TakeFromBankroll(BigBlind);
                        CurrentBank += BigBlind;
                        break;
                }
            }
        }

        // TO DO
        public void PlayRound()
        {
            DealCardsToPlayers();
            RandomlySelectButtonPosition();
            DefinePlayersPosition();
            PostBlinds();
            ShowPlayersBalance();

            // DealFlop();
        }

        public void DetermineWinnerByShowDown()
        {

        }

        public void MakeDecision()
        {
            for (int i = 0; i < players.Count; i++)
            {
                if(round < Round.River)
                {
                    if (players[i].IsInGame)
                    {
                        players[i].MakeDecision();
                        switch (players[i].Decision)
                        {
                            case PlayersDecision.Fold:                              
                                break;
                            case PlayersDecision.Check:                               
                                break;
                            case PlayersDecision.Call:
                                break;
                            case PlayersDecision.Bet:
                                break;
                            case PlayersDecision.Raise:
                                break;
                        }
                    }
                }
                else
                {
                    DetermineWinnerByShowDown();
                }
            }
        }
    }
}