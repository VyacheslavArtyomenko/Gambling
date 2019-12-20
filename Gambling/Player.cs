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
        public int Position { get; set; }

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
    }
}
