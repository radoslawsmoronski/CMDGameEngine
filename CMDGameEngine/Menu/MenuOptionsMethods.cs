using CMDGameEngine.Additional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Useful method to use in GameMenu like. ExitGame()

namespace CMDGameEngine.Menu
{
    public static class MenuOptionsMethods
    {
        public static void ExitGame(GameMenu gameMenu)
        {
            gameMenu.CloseMenu();

            if (ConsoleMessages.Confirmation("Do you want exit game?"))
            {
                return;
            }

            gameMenu.Show();
        }
    }
}
