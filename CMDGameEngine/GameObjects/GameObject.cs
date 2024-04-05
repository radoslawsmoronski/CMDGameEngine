using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDGameEngine.GameObjects
{
    public class GameObject
    {
        public int X { get; set; }
        public int Y { get; set; }

        public GameObject(int x, int y)
        {
            X = x;
            Y = y;

            GameObjects.AddObject(this);
        }

        public void Move(int x, int y)
        {
            X = X + x;
            Y = Y + y;

        }

    }
}
