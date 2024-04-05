using CMDGameEngine.Menu;

namespace CMDSupportProject
{
    internal class Program
    {
        static GameMenu gameMenu = new GameMenu("New Game", null);
        static void Main(string[] args)
        {
            List<MenuOption> menuOptions = new List<MenuOption>();

            menuOptions.Add(new MenuOption("Start Game", () => StartGame()));
            menuOptions.Add(new MenuOption("Exit Game", () => MenuOptionsMethods.ExitGame(gameMenu)));

            gameMenu.AddMenuOptions(menuOptions);


            gameMenu.Show();
        }

        public static void StartGame()
        {
            gameMenu.CloseMenu();
            Console.WriteLine("Hello!");
        }

    }
}
