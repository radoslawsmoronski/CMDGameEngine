using CMDGameEngine.GameObjects;
using CMDGameEngine.GameObjects.VisualMap;
using CMDGameEngine.Menu;
using CMDGameEngine.Screen;
using CMDGameEngine.Additional;
using System.Linq.Expressions;

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

        static GameScreen newScreen = new GameScreen(80, 20, "test");
        List<Block> blocks = new List<Block>();

        private static void StartGame()
        {

            VisualMap blockVisualMap = new VisualMap("block.xml");

            List<Block> blocks = new List<Block>();

            int previousBlockX = 0;

            for (int i = 0; i <= 3; i++)
            {
                Random random = new Random();

                int minY = -11;
                int maxY = -3;
                int randomY = random.Next(minY, maxY + 1);

                int minX = 0;
                int maxX = 20;
                int randomX = random.Next(minX, maxX + 1);

                blocks.Add(new Block(previousBlockX+randomX, randomY, blockVisualMap));

                previousBlockX += randomX + 40;
            }



            gameMenu.CloseMenu();


            Thread inputThread = new Thread(Controller);
            inputThread.Start();

            newScreen.Show();

            int scene = 1;
            int points = 0;

            while (true)
            {
                newScreen.HeaderText = $"Camera X: {newScreen.CameraX} scene: {scene} points: {points}";

                Thread.Sleep(25);

                if(newScreen.CameraX/scene == newScreen.ScreenWidth)
                {
                    foreach(Block block in blocks)
                    {
                        if(block.X+5 < newScreen.CameraX)
                        {
                            Random random = new Random();

                            int minY = -11;
                            int maxY = -3;
                            int randomY = random.Next(minY, maxY + 1);

                            int minX = 30;
                            int maxX = 60;
                            int randomX = random.Next(minX, maxX + 1);

                            int x = GetMaxXFromBlocks(blocks);
                            block.SetPosition(x + randomX, randomY);
                        }
                    }


                    scene++;
                }

                bird.Move(+1, 0);
                newScreen.MoveCamera(+1, 0);
                
                foreach(Block block in blocks)
                {
                    if ((bird.X) == block.X+5)
                    {
                        points++;
                    }
                }
            }
        }

        private static int GetMaxXFromBlocks(List<Block> blocks)
        {
            int max = 0;

            foreach(Block block in blocks)
            {
                if(block.X > max) max = block.X;
            }

            return max;
        }

        private static bool CreateObjects()
        {
            try
            {
                VisualMap birdVisualMap = new VisualMap("bird1.xml");

                bird = new Bird(10, 4, birdVisualMap);

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
