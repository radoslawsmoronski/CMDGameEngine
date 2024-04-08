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

        private static void StartGame()
        {
            gameMenu.CloseMenu();

            GameScreen newScreen = new GameScreen(60, 15);

            Thread inputThread = new Thread(Controller);
            inputThread.Start();

            Thread bitdPhysics = new Thread(SimulateBirdPhysics);
            bitdPhysics.Start();

            newScreen.Show();
        }

        private static void SimulateBirdPhysics()
        {
            while (true)
            {
                Thread.Sleep(150);
                bird.Move(0, +1);
                Thread.Sleep(150);
                bird.Move(0, +1);
            }
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
            }
        }


    }
}
