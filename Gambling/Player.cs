using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambling
{
    class Player
    {
        public string Name { get; private set; }
        public int Bankroll { get; private set; }
        public Card FirstCard { get; set; }
        public Card SecondCard { get; set; }

        public PlayersPosition Position { get; set; } = PlayersPosition.Other;

        public PlayersDecision Decision { get; set; } = PlayersDecision.Undefined;

        public bool IsInGame { get; set; } = true;

        public int CurrentBet { get; set; } = 0;

        public Player(string name)
        {
            Name = name;
            Bankroll = 1000;
        }

        public Player(string name, int bankroll)
        {
            Name = name;
            Bankroll = bankroll;
        }

        public void AddToBankroll(int amount)
        {
            Bankroll += amount;
        }

        public void TakeFromBankroll(int amount)
        {
            if (Bankroll < amount || Bankroll <= 0)
            {
                Console.WriteLine($"Player {Name} has not enough money in the bankroll");
                return;
            }
            Bankroll -= amount;
        }

        public void ShowHand()
        {
            Console.WriteLine($"{Name}: ");
            Console.WriteLine($"{FirstCard}, {SecondCard}");
            Console.WriteLine();
        }

        public void ShowBalance()
        {
            Console.WriteLine($"{Name}: {Bankroll}");
            Console.WriteLine();
        }

        // TO DO
        public void MakeDecision()
        {
            Console.WriteLine($"Player {Name}");
            Console.WriteLine("Press 1 to Fold");
            Console.WriteLine("Press 2 to Check");
            Console.WriteLine("Press 3 to Call");
            Console.WriteLine("Press 4 to Bet");
            Console.WriteLine("Press 5 to Raise");

            int tempDecision = Convert.ToInt32(Console.ReadLine());

            switch (tempDecision)
            {
                case 1:
                    Decision = PlayersDecision.Fold;
                    IsInGame = false;
                    Console.WriteLine($"Player {Name} folds");
                    break;
                case 2:
                    Decision = PlayersDecision.Check;
                    Console.WriteLine($"Player {Name} checks");
                    break;
                case 3:
                    Decision = PlayersDecision.Call;
                    Console.WriteLine($"Player {Name} calls");
                    break;
                case 4:
                    Decision = PlayersDecision.Bet;
                    Console.WriteLine($"Player {Name} bets");
                    break;
                case 5:
                    Decision = PlayersDecision.Raise;
                    Console.WriteLine($"Player {Name} raises");
                    break;
            }
        }

    }

    enum PlayersDecision { Fold, Check, Call, Bet, Raise, Undefined };
    enum PlayersPosition { Button, SmallBlind, BigBlind, Other };
}
