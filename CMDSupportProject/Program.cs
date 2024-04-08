using CMDGameEngine.GameObjects;
using CMDGameEngine.GameObjects.VisualMap;
using CMDGameEngine.Menu;
using CMDGameEngine.Screen;
using CMDGameEngine.Additional;

namespace CMDSupportProject
{
    internal class Program
    {

        static string headerString =
            "Game                \n" +
            "by author           \n" +
            "             ver 1.0";

        static GameMenu gameMenu = new GameMenu(headerString, null);

        static Bird bird = null;

        static void Main(string[] args)
        {
            if (!CreateObjects()) return;

            List<MenuOption> menuOptions = new List<MenuOption>();

            menuOptions.Add(new MenuOption("Start Game", () => StartGame()));
            menuOptions.Add(new MenuOption("Exit Game", () => MenuOptionsMethods.ExitGame(gameMenu)));

            gameMenu.AddMenuOptions(menuOptions);

            gameMenu.Show();
        }

        static GameScreen newScreen = new GameScreen(60, 15);

        private static void StartGame()
        {
            gameMenu.CloseMenu();


            Thread inputThread = new Thread(Controller);
            inputThread.Start();

            newScreen.Show();
        }

        private static bool CreateObjects()
        {
            try
            {
                VisualMap birdVisualMap = new VisualMap("bird1.xml");

                bird = new Bird(0, 4, birdVisualMap);


                return true;
            }
            catch (Exception ex)
            {
                ConsoleMessages.Error(ex.Message);
                return false;
            }
        }

        private static void Controller()
        {
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Spacebar)
                {
                    bird.Jump();
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    newScreen.MoveCamera(+1, 0);
                }
            }
        }


    }
}
