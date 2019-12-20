using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambling
{
    class Player
    {
        public string Name { get; set; }
        public int Bankroll { get; set; }
        public Card FirstCard { get; set; }
        public Card SecondCard { get; set; }

        public Player(string name)
        {
            Name = name;
            Bankroll = 1000;
        }

        public void ShowHand()
        {
            Console.WriteLine($"{Name}: ");
            Console.WriteLine($"{FirstCard}, {SecondCard}");
            Console.WriteLine();
        }
    }
}
