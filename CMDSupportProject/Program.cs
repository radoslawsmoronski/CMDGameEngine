using CMDGameEngine.Menu;

namespace CMDSupportProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<MenuOption> menuOptions = new List<MenuOption>();
            
            menuOptions.Add(new MenuOption("Start Game", () =>
            {
                Console.WriteLine("Executing action...");
            }));

            menuOptions.Add(new MenuOption("Exit", () =>
            {
                Console.WriteLine("Executing action...");
            }));


            GameMenu gameMenu = new GameMenu(menuOptions, "New Game", null);

            gameMenu.Show();
        }

    }
}
