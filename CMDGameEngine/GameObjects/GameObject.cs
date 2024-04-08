using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Game Object class, objects used directly in the game, such as background, obstacles or something.

namespace CMDGameEngine.GameObjects
{
    public class GameObject
    {
        public int X { get; set; }
        public int Y { get; set; }

        public char Sign { get; set; }

        public GameObject(int x, int y)
        {
            X = x;
            Y = y;

            GameObjects.AddObject(this); // Adding object to static GameObjects list
        }

        public void Move(int x, int y)
        {
            X = X + x;
            Y = Y + y;
        }

    }
}
