using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Class to containt a visual part of an object.

namespace CMDGameEngine.Objects.VisualMap
{
    public class VisualMap
    {
        
        public List<VisualElement> visualElements { get; private set; }

        private Dictionary<char, char> invertedSigns = null;

        public VisualMap(string? xml)
        {
            if (xml == null) throw new ArgumentNullException(nameof(xml));

            visualElements = XMLOperations.GetVisualElementsFromXML(xml);
        }

        public char? GetSignOn(GameObject obj, int _x, int _y)
        {
            foreach (VisualElement element in visualElements)
            {
                int x = element.XPosToVisualMap + obj.X;
                int y = element.YPosToVisualMap + obj.Y;
                
                if (x == _x && y == _y)
                {
                    return element.Sign;
                }
            }

            return null;
        }

        public void RotateX(bool isChangeSideSigns = false)
        {
            int visualMapWidth = 0;

            foreach (VisualElement element in visualElements) // Getting visualMapWidth value 
            {
                if(element.XPosToVisualMap > visualMapWidth) visualMapWidth = element.XPosToVisualMap;
            }

            foreach (VisualElement element in visualElements)
            {
                int oldX = element.XPosToVisualMap;

                element.XPosToVisualMap = Math.Abs(oldX - visualMapWidth);

                if(isChangeSideSigns)
                {
                    element.Sign = GetRotateSign(element.Sign);
                }
            }
        }

        private char GetRotateSign(char sign)
        {
            if(invertedSigns == null)
            {
                invertedSigns = new Dictionary<char, char>
                {
                    { '(', ')' },
                    { '[', ']' },
                    { '{', '}' },
                    { '/', '\\' },
                    { '\\', '/' },
                    { '<', '>' }
                };
            }

            char signToReturn = sign;

            foreach (KeyValuePair<char, char> pair in invertedSigns)
            {
                if (sign == pair.Key) signToReturn = pair.Value;
                else if (sign == pair.Value) signToReturn = pair.Key;
            }

            return signToReturn;
        }

    }
}
