using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This class is a part of the VisualMap, and containt char on specific position in the game.

namespace CMDGameEngine.Objects.VisualMap
{
    public class VisualElement
    {
        public int XPosToVisualMap { get; private set; }
        public int YPosToVisualMap { get; private set; }

        public char Sign {  get; private set; }

        public VisualElement(int x, int y, char sign)
        {
            XPosToVisualMap = x;
            YPosToVisualMap = y;
            Sign = sign;
        }
    }
}
