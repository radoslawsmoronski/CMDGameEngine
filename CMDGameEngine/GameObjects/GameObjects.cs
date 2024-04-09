using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMDGameEngine.GameObjects.VisualMap;

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
                if (obj.VisualMap == null) continue;
                
                VisualMap.VisualMap visualMap = obj.VisualMap;

                char? sign = visualMap.GetSignOn(obj, x, y);

                if (sign != null) return (char)sign;
            }

            return ' ';
        }

        public static bool IsObjectsCollide(GameObject obj1, GameObject obj2)
        {
            VisualMap.VisualMap visualMap = obj1.VisualMap;
            VisualMap.VisualMap visualMap2 = obj2.VisualMap;

            foreach (VisualElement visualElement in visualMap.visualElements)
            {
                foreach (VisualElement visualElement2 in visualMap2.visualElements)
                {
                    int x = visualElement.XPosToVisualMap + obj1.X;
                    int y = visualElement.YPosToVisualMap + obj1.Y;
                    int x2 = visualElement2.XPosToVisualMap + obj2.X;
                    int y2 = visualElement2.YPosToVisualMap + obj2.Y;

                    if(x == x2 && y == y2) return true;
                }
            }

            return false;
        }

    }
}
