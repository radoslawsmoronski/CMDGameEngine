using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Class to containt a visual part of an object.

namespace CMDGameEngine.GameObjects.VisualMap
{
    public class VisualMap
    {
        List<VisualElement> visualElements;

        public VisualMap(string? xml)
        {
            if (xml == null) throw new ArgumentNullException(nameof(xml));

            visualElements = XMLOperations.GetVisualElementsFromXML(xml);
        }
    }
}
