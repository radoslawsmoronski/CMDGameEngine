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
        public bool IsScreenOn { get; private set; } = true;

        public int ScreenWidth { get; private set; }
        public int ScreenHeight { get; private set; }

        public Frame screenFrame { get; private set; }

        public string? HeaderText { get; private set; } = null;

        public Screen(int screenWidth = 50, int screenHeight = 20, string? headerText = null) 
        {
            ScreenWidth = screenWidth;
            ScreenHeight = screenHeight;

            screenFrame = new Frame();

            if (headerText != null)
            {
                HeaderText = headerText;
            }
        }

        public void Show()
        {
            while(IsScreenOn)
            {
                GetScreenFramePerIteration();
            }
        }

        public string GetScreenFramePerIteration()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine();
            
            if(HeaderText != null)
            {
                stringBuilder.Append(" " + HeaderText);
                stringBuilder.AppendLine();
                stringBuilder.AppendLine();
            }

            for (int preY = 0; preY < (ScreenHeight + 2); preY++)
            {
                stringBuilder.Append(" ");
                for (int preX = 0; preX < (ScreenWidth + 2); preX++)
                {
                    if (preX == 0 || preY == 0 || preX == (ScreenWidth + 1) || preY == (ScreenHeight + 1))
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
