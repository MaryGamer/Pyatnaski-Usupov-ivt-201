using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last_Version_15_2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(1, 2, 3, 4, 5, 6, 7, 8, 0);
            Game2 game2 = new Game2(1, 2, 3, 4, 5, 6, 7, 0, 8);
            Print.PrintInfo(game.Numbers);
            game.Shift(8);
            game.Shift(5);
            Print.PrintInfo(game.Numbers);
            Console.WriteLine("Позиция числа 5: {0}", game.GetLocation(5));
            Console.WriteLine("Позиция пустышки: {0}", game.GetLocation(0));
            Print.PrintInfo(game2.Numbers);
            
            
        }
    }
}
