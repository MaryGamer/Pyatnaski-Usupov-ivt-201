using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last_Version_15_2_3
{
    public static class Print
    {
        public static void PrintInfo(int[,] array)
        {
            Console.WriteLine("Игровое поле");
            for (int i = 0; i < Math.Sqrt(array.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(array.Length); j++)
                {
                    Console.Write("{0}\t", array[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

    }
}
