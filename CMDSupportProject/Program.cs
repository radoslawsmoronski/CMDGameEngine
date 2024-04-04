using CMDGameEngine;

namespace CMDSupportProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> menuOptions = new List<string>();
            menuOptions.Add("Start Game");
            menuOptions.Add("Exit Game");

            GameMenu gameMenu = new GameMenu(menuOptions, "test\nto ja\nelo\n5\ngdfgdfgfd\ngdfgfd", "test");

            gameMenu.Show();
        }
    }
}
