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

        private Dictionary<char, char> invertedXSigns = null;

        public VisualMap(string? xml = null)
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
                    element.Sign = GetRotateXSign(element.Sign);
                }
            }
        }

        private char GetRotateXSign(char sign)
        {
            if (invertedXSigns == null)
            {
                invertedXSigns = new Dictionary<char, char>
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

            foreach (KeyValuePair<char, char> pair in invertedXSigns)
            {
                if (sign == pair.Key) signToReturn = pair.Value;
                else if (sign == pair.Value) signToReturn = pair.Key;
            }

            return signToReturn;
        }

        public void RotateY()
        {
            int visualMapHeight = 0;

            foreach (VisualElement element in visualElements)
            {
                if (element.YPosToVisualMap > visualMapHeight) visualMapHeight = element.YPosToVisualMap;
            }

            foreach (VisualElement element in visualElements)
            {
                int oldY = element.YPosToVisualMap;

                element.YPosToVisualMap = Math.Abs(oldY - visualMapHeight);
            }
        }

    }
}
