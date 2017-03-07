using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Last_Version_15_2_3
{

    class Game
    {
        private int Voidx = 0, Voidy = 0, firstNumber = 0, secondNumber = 0;
        public readonly int Side;
        public int[,] Numbers;
        private Dictionary<int, Tuple<int, int>> dictionary = new Dictionary<int, Tuple<int, int>>();

        public Game(params int[] values)
        {
            if (!IsThisCorrectArray(values)) throw new ArgumentException("Значения в данном массиве некорректны");
            if (!IsItIntegerSize(values.Length)) throw new ArgumentException("Размер поля с данными аргументами не может существовать");
            Side = (int)Math.Sqrt(values.Length);
            GetMatrix(values);
        }



        protected virtual void GetMatrix(int[] values)
        {
            int count = 0;
            bool existVoid = false;
            Numbers = new int[Side, Side];

            for (int i = 0; i < Side; i++)
            {
                for (int j = 0; j < Side; j++)
                {
                    if (values[count] == 0)
                    {
                        Voidx = i;
                        Voidy = j;
                        Numbers[i, j] = values[count];
                        var primes = Tuple.Create(i, j);
                        dictionary.Add(Numbers[i, j], primes);
                        count++;
                        existVoid = true;

                    }
                    else
                    {
                        Numbers[i, j] = values[count];
                        var primes = Tuple.Create(i, j);
                        dictionary.Add(Numbers[i, j], primes);
                        count++;
                    }
                }
            }
            if (!existVoid) throw new ArgumentException("В этих данных нет нуля");
        }



        public int this[int x, int y] 
        {
            get
            {
                return Numbers[x, y];
            }
        }



        public Tuple<int, int> GetLocation(int value)
        {
            if ((value < Math.Pow(Side, 2)) && (value >= 0))
            {
                var Cortege = Tuple.Create(dictionary[value].Item1, dictionary[value].Item2);
                return Cortege;
            }
            else throw new ArgumentException("Данное число " + value + " не удалось найти");
        }



        public virtual void Shift(int value) 
        {
            if ((value >= 0) && (value < Side * Side))
            {
                firstNumber = dictionary[value].Item1;
                secondNumber = dictionary[value].Item2;
                if (Math.Abs(firstNumber - Voidx) + Math.Abs(secondNumber - Voidy) == 1)
                {
                    Numbers[Voidx, Voidy] = Numbers[firstNumber, secondNumber];
                    dictionary.Remove(0);
                    dictionary.Remove(value);
                    var coordinatesVoid = Tuple.Create(Voidx, Voidy);
                    var coordinatesValue = Tuple.Create(firstNumber, secondNumber);
                    dictionary.Add(value, coordinatesVoid);
                    dictionary.Add(0, coordinatesValue);
                    Voidx = firstNumber;
                    Voidy = secondNumber;
                    Numbers[Voidx, Voidy] = 0;
                }
                else
                {
                    throw new ArgumentException("Данное число " + value + " невозможно поменять местами с нулем");
                }
            }
            else
            {
                throw new ArgumentException("Данное число " + value + " не удалось найти");
            }
        }



        private bool IsItIntegerSize(int size)
        {
            return ((Math.Sqrt(size) % 1) == 0);
        }



        private bool IsThisCorrectArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if ((!array.Contains(i)) || (array[i] < 0))
                {
                    return false;
                }
            }
            return true;
        }



        public static Game FromCSV(string file)
        {
            string[] data = File.ReadAllLines(file);
            List<int> list = new List<int>();
            for (int i = 0; i < data.Count(); i++)
            {
                for (int j = 0; j < data[i].Split(';').Count(); j++)
                {
                    list.Add(Convert.ToInt32(data[i].Split(';')[j]));
                }
            }
            Game game = new Game(list.ToArray<int>());
            return game;
        }
    }
}
