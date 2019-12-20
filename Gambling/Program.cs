using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Gambling
{
    delegate void TestDelegate(int number);

    class Program
    {
    
        public static void Main()
        {
            // Test
            Game game = new Game();
            game.AddPlayer("Vyacheslav");
            game.AddPlayer("Tolyan");
            game.AddPlayer("Vasya");

            game.DealCardsToPlayers();

            game.PostBlinds();


            Console.ReadKey();

        }
    }
}


