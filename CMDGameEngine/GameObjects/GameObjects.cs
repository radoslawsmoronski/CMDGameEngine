using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDGameEngine.GameObjects
{
    public static class GameObjects
    {
        private static List<GameObject> gameObjects = new List<GameObject>();
        public static List<GameObject> GetObjects() { return gameObjects; }

        public static void AddObject(GameObject obj)
        {
            gameObjects.Add(obj);
        }

        public static void RemoveObjects()
        {
            gameObjects = new List<GameObject>();
        }

    }
}
