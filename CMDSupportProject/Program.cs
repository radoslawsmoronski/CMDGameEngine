using CMDGameEngine.GameObjects;
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
            GameObject object1 = new GameObject(0, 0);
            object1.Sign = 't';

            GameObject object2 = new GameObject(5, 6);
            object2.Sign = 'g';

            GameObject object3 = new GameObject(1, 4);
            object3.Sign = 'h';


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
