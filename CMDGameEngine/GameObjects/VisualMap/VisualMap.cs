using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Class to containt a visual part of an object.

namespace CMDGameEngine.GameObjects.VisualMap
{
    public class VisualMap
    {
        
        public List<VisualElement> visualElements { get; private set; }

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

    }
}
