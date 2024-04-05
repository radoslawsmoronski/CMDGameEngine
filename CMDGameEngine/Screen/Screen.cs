using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace CMDGameEngine.Screen
{
    public class Screen
    {
        public int ScreenWidth { get; private set; }
        public int ScreenHeight { get; private set; }

        public Screen(int screenWidth = 20, int screenHeight = 20) 
        {

            ScreenWidth = screenWidth;
            ScreenHeight = screenHeight;
        }
    }
}
