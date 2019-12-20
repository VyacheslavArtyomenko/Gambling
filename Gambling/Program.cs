using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Gambling
{
    class Program
    {
        public static void Main()
        {
            Game game = new Game();
            game.AddPlayer("Vyacheslav");
            game.AddPlayer("Tolyan");

            game.DealCardsToPlayers();

            game.DealFlop();
            game.DealTurn();
            game.DealRiver();

            game.ShowBoard();
        }
    }  
}


