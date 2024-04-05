using CMDGameEngine.Additional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDGameEngine.Screen
{
    public class Screen
    {
        public int ScreenWidth { get; private set; }
        public int ScreenHeight { get; private set; }

        public Frame screenFrame { get; private set; }

        public Screen(int screenWidth = 20, int screenHeight = 20) 
        {
            ScreenWidth = screenWidth;
            ScreenHeight = screenHeight;

            screenFrame = new Frame();
        }

        public string GetScreenFramePerIteration()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for(int preY = 0; preY < (ScreenHeight+2); preY++)
            {
                for (int preX = 0; preX < (ScreenWidth + 2); preX++)
                {
                    if (preX == 0 || preY == 0 || preX == (ScreenHeight + 1) || preY == (ScreenWidth + 1))
                    {
                        stringBuilder.Append(screenFrame.GetFrameSignOn(preX, preY, ScreenWidth+1, ScreenHeight+1));
                        continue;
                    }

                    int screenX = preX + 1;
                    int screenY = preY + 1;

                    stringBuilder.Append("*");
                }
                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }
    }
}
