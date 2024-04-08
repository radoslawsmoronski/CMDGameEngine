using CMDGameEngine.GameObjects;
using CMDGameEngine.GameObjects.VisualMap;
using CMDGameEngine.Menu;
using CMDGameEngine.Screen;

namespace CMDSupportProject
{
    internal class Program
    {

        static string headerString =
            "Game                \n" +
            "by author           \n" +
            "             ver 1.0";

        static GameMenu gameMenu = new GameMenu(headerString, null);

        static void Main(string[] args)
        {
            VisualMap dragon = new VisualMap("dragon.xml");
            GameObject object1 = new GameObject(0, 0, dragon);
            



            List<MenuOption> menuOptions = new List<MenuOption>();

            menuOptions.Add(new MenuOption("Option 1", () => StartGame()));
            menuOptions.Add(new MenuOption("Option 2", () => StartGame()));
            menuOptions.Add(new MenuOption("Exit Game", () => MenuOptionsMethods.ExitGame(gameMenu)));

            gameMenu.AddMenuOptions(menuOptions);


            gameMenu.Show();
        }

        public static void StartGame()
        {
            gameMenu.CloseMenu();

            GameScreen newScreen = new GameScreen(50, 20, "test");

            newScreen.Show();
        }


    }
}
