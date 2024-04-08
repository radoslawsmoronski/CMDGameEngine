using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDGameEngine.GameObjects
{

    // Class which is focus on contain GameObjects
    public static class GameObjects
    {
        private static List<GameObject> gameObjects = new List<GameObject>(); // This is list which containt every GameObjects in the game
        public static List<GameObject> GetObjects() { return gameObjects; }

        public static void AddObject(GameObject obj)
        {
            gameObjects.Add(obj);
        }

        public static void RemoveObjects()
        {
            gameObjects = new List<GameObject>();
        }

        public static char GetObjectsCharOn(int x, int y)
        {
            foreach (GameObject obj in gameObjects)
            {
                if (obj.X == x && obj.Y == y) return obj.Sign;
            }

            return ' ';
        }

    }
}
