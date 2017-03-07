using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last_Version_15_2_3
{
    class Game3 : Game2
    {
        public List<int> history;

        public Game3(params int[] list)
            : base(list)
        {
            history = new List<int>();
        }

        public override void Shift(int value)
        {
            base.Shift(value);
            history.Add(value);
        }


        public void StepDown()
        {
            this.Shift(history.Last());
            history.Remove(history.Last());
        }
    }
}
