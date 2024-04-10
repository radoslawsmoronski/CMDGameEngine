using CMDGameEngine.Objects;
using CMDGameEngine.Objects.VisualMap;
using CMDGameEngine.Menu;
using CMDGameEngine.Screen;
using CMDGameEngine.Additional;
using System.Linq.Expressions;
using static System.Reflection.Metadata.BlobBuilder;

namespace CMDSupportProject
{

    internal class Program
    {
        // Game Menu 
        static string headerString =
            "                    \n" +
            "    Falling bird    \n" +
            "                    ";

        static string additionalHeaderString = "Sample game created on\nCMDGameEngine.\n\nBy Radoslaw Smoronski";

        static GameMenu gameMenu = new GameMenu(headerString, additionalHeaderString);


        // Game Screen
        static GameScreen gameScreen;


        // Game Objects
        static Bird bird;
        static List<GameObject> blocks;

        
        //Bool to turn of Controller Thread
        static bool IsControlerWork = false;


        static void Main(string[] args)
        {
            List<MenuOption> menuOptions = new List<MenuOption>(); // Creating menu options list

            menuOptions.Add(new MenuOption("Start Game", () => StartGame())); // Adding option 1 with new custom method
            menuOptions.Add(new MenuOption("Exit Game", () => MenuOptionsMethods.ExitGame(gameMenu)));  // Adding option 2 and including default Exit Game method from MenuOptionsMethods 

            gameMenu.AddMenuOptions(menuOptions); // Adding menu option list to the menu

            gameMenu.Show(); // Show the menu in the console
        }

        static void StartGame()
        {
            gameScreen = new GameScreen(80, 20, "Points"); // Create Game Screen with additional text above the screen

            if (!CreateObjects()) return; // Create bird and blocks

            gameMenu.CloseMenu(); // Close Menu

            Thread controllerThread = new Thread(Controller);
            controllerThread.Start(); // Start bird controller

            gameScreen.Show(); // Show Game screen in the console

            int scene = 1; // Counter how many screen width has been scrolled by Screen Camera
            int points = 0; // Game points

            bool IsGameOver = false;

            while (true)
            {
                gameScreen.HeaderText = $"Points {points}"; // Showing game points above the game screen

                Thread.Sleep(25);

                if(gameScreen.CameraX/scene == gameScreen.ScreenWidth) // Checking whether the camera has flown through the scene
                {

                    // Moves elements that disappeared with the screen to the next scenes 
                    foreach (GameObject block in blocks)
                    {
                        if(block.X+5 < gameScreen.CameraX)
                        {
                            Random random = new Random();

                            int minY = -11;
                            int maxY = -3;
                            int randomY = random.Next(minY, maxY + 1);

                            int minX = 30;
                            int maxX = 60;
                            int randomX = random.Next(minX, maxX + 1);

                            int x = GetTheBiggestXFromBlocks(blocks);
                            block.SetPosition(x + randomX, randomY);
                        }
                    }


                    scene++;
                }

                // Check is bird under the screen
                if(bird.Y+5 > gameScreen.ScreenHeight) GameOver(points);

                // Check is bird collide with blocks or got a point
                foreach (GameObject block in blocks)
                {
                    if (GameObjects.IsObjectsCollide(bird, block))
                    {
                        bird.Move(-2, 0);
                        Thread.Sleep(100);
                        bird.Move(-2, 0);
                        IsControlerWork = false;
                        IsGameOver = true;
                    }

                    if ((bird.X) == block.X + 5)
                    {
                        points++;
                        Console.Beep(400, 40);
                    }
                }



                if(IsGameOver == false)
                {
                    bird.Move(+1, 0);
                    gameScreen.MoveCamera(+1, 0);
                }
                else if (IsGameOver == true)
                {
                    bird.Move(-1, 2);
                    Console.Beep(200, 250);
                    Thread.Sleep(250);
                }
            }
        }

        static int GetTheBiggestXFromBlocks(List<GameObject> objs)
        {
            int max = 0;

            foreach(GameObject obj in objs)
            {
                if(obj.X > max) max = obj.X;
            }

            return max;
        }

        static bool CreateObjects()
        {
            try
            {
                // Bird
                VisualMap birdVisualMap = new VisualMap("bird1.xml");
                bird = new Bird(10, 4, birdVisualMap);


                //Blocks
                blocks = new List<GameObject>();

                VisualMap blockVisualMap = new VisualMap("block.xml");

                int previousBlockX = gameScreen.ScreenWidth/2;

                for (int i = 0; i <= 3; i++)
                {
                    Random random = new Random();

                    int minY = -11;
                    int maxY = -3;
                    int randomY = random.Next(minY, maxY + 1);

                    int minX = 0;
                    int maxX = 20;
                    int randomX = random.Next(minX, maxX + 1);

                    blocks.Add(new GameObject(previousBlockX + randomX, randomY, blockVisualMap));

                    previousBlockX += randomX + 40;
                }

                return true;
            }
            catch (Exception ex)
            {
                ConsoleMessages.Error(ex.Message);
                return false;
            }
        }

        static void Controller()
        {
            IsControlerWork = true;

            while (IsControlerWork)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Spacebar)
                {
                    bird.Jump();
                }
            }
        }

        private static void GameOver(int points)
        {
            Console.Beep(1000, 50);
            Console.Beep(800, 100);
            Console.Beep(600, 200);

            IsControlerWork = false;

            gameScreen.CloseScreen();

            GameObjects.RemoveObjects();

            Console.WriteLine($"Game Over!\nYou've got {points} points! Press double..");

            Console.ReadKey(true);  

            gameMenu.Show();
        }


    }
}
