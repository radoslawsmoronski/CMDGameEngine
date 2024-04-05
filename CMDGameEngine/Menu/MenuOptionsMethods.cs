using CMDGameEngine.Additional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
