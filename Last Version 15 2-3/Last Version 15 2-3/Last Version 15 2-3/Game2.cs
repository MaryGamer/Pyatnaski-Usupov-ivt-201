using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last_Version_15_2_3
{

    class Game2 : Game
    {
       
        public Game2(params int[] values)
            : base(values)
        {
            Randomize(values);
            if (ThisGameIsEnd()) throw new ArgumentException("Эта игра окончена");
        }




        private void Randomize(int[] values)
        {
          
            int count = 0;
            Random rnd = new Random();
            while (count != values.Length)
            {
                int a = rnd.Next(0, values.Length);
                ShiftForRandomize(a);
                count++;
            }         
        }



        private void ShiftForRandomize(int value)
        {
            
            var firstNumber = this.GetLocation(value).Item1;
            var secondNumber = this.GetLocation(value).Item2;
            var Voidx = this.GetLocation(0).Item1;
            var Voidy = this.GetLocation(0).Item2;
            var cellValue=this.Numbers[Voidx,Voidy];
            this.Numbers[Voidx, Voidy] = this.Numbers[firstNumber, secondNumber];
            Voidx = firstNumber;
            Voidy = secondNumber;
            this.Numbers[Voidx, Voidy] = cellValue;
        }




        public bool ThisGameIsEnd()
        {
            int count = 1, lastValue = Side;

            for (int i = 0; i < Side; i++)
            {
                for (int j = 0; j < Side; j++)
                {
                    if ((i != Side - 1) || (j != Side - 1))
                    {
                        if (Numbers[i, j] != count)
                        {
                            return false;
                        }
                        count++;
                    }
                    else if (Numbers[Side - 1, Side - 1] != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

       
    }
}
