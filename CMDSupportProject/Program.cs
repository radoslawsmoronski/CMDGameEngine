using CMDGameEngine.Menu;

namespace CMDSupportProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<MenuOption> menuOptions = new List<MenuOption>();
            
            menuOptions.Add(new MenuOption("Exit", () =>
            {
                Console.WriteLine("Executing action...");
            }));

            menuOptions.Add(new MenuOption("Exit2", () =>
            {
                Console.WriteLine("Executing action...");
            }));

            GameMenu gameMenu = new GameMenu(menuOptions, "test", "test");

            gameMenu.Show();
        }

    }
}
