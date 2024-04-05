using CMDGameEngine.Menu;

namespace CMDSupportProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameMenu gameMenu = new GameMenu("New Game", null);

            List<MenuOption> menuOptions = new List<MenuOption>();

            menuOptions.Add(new MenuOption("Start Game", () => MenuOptionsMethods.ExitGame(gameMenu)));

            gameMenu.AddMenuOptions(menuOptions);


            gameMenu.Show();
        }

    }
}
