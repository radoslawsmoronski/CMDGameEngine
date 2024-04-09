using CMDGameEngine.Additional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// GameScreen class is use to draw all game objects on the virutal console screen.

namespace CMDGameEngine.Screen
{
    public class GameScreen
    {
        public bool IsScreenOn { get; private set; }  // Bool which is use to turn off menu

        public int ScreenWidth { get; private set; }
        public int ScreenHeight { get; private set; }

        public int CameraX { get; private set; } // Camera position X
        public int CameraY { get; private set; } // Camera position Y


        public Frame screenFrame { get; private set; }

        public string? HeaderText { get; set; } // Optional text displayed above the menu in the frame.

        public GameScreen(int screenWidth = 50, int screenHeight = 20, string? headerText = null) 
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
            Thread screenThread = new Thread(() =>
            {
                IsScreenOn = true;
                Console.CursorVisible = false;
                Console.Clear();

                while (IsScreenOn)
                {
                    Console.SetCursorPosition(0, 0);

                    string screenFramePerIteration = GetScreenFramePerIteration();
                    Console.WriteLine(screenFramePerIteration);
                }
            });

            screenThread.Start();
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

                    int screenX = preX - 1 + CameraX;
                    int screenY = preY - 1 + CameraY;

                    stringBuilder.Append(GameObjects.GameObjects.GetObjectsCharOn(screenX, screenY));
                }
                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }

        public void CloseScreen()
        {
            IsScreenOn = false;
            Console.CursorVisible = true;
            Console.Clear();
        }

        public void MoveCamera(int x, int y)
        {
            CameraX += x;
            CameraY += y;
        }
    }
}
