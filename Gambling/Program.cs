using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Gambling
{
    delegate void TestDelegate();

    class EventContainer
    {
        public event TestDelegate testEvent;

        public void InvokeEvent()
        {
            if (testEvent != null)
                testEvent();
        }
    }


    class Program
    {
        public static void SomeHandler()
        {
            Console.WriteLine("Event has been handled!");
        }
    
        public static void Main()
        {
            EventContainer eventContainer = new EventContainer();
            eventContainer.testEvent += SomeHandler;
            eventContainer.InvokeEvent();

            // Test
            Game game = new Game();
            game.AddPlayer("Vyacheslav");
            game.AddPlayer("Tolyan");
            game.AddPlayer("Vasya");

            game.PlayRound();

            game.ShowPlayersBalance();
            Console.WriteLine("Chips in bank: {0}", game.CurrentBank);

            Console.ReadKey();

        }
    }
}

/*TO DO:
- improve algorith of defining player's position
- add history of each round to database
- implement decision making mechanism
- implement decisions methods realization
- implement combination checking
- implement event mechanism?

*/
