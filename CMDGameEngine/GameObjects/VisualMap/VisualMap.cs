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
        List<VisualElement> visualElements = new List<VisualElement>();

        public VisualMap(List<VisualElement> visualElements)
        {
            this.visualElements = visualElements;
        }
    }
}
