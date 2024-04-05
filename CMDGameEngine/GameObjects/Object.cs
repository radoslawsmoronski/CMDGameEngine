using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDGameEngine.GameObjects
{
    public class Object
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Object(int x, int y)
        {
            X = x;
            Y = y;

        }

        public void Move(int x, int y)
        {
            X = X + x;
            Y = Y + y;

        }

    }
}
