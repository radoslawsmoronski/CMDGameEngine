namespace CMDGameEngine
{
    public class GameMenu
    {
        List<string> menuOptions;
        public string? HeaderText { get; private set; }
        public string? AdditionalText { get; private set; }

        public GameMenu(List<string> menuOptions, string? headerText, string? additionalText)
        {
            this.menuOptions = menuOptions;
            HeaderText = headerText;
            AdditionalText = additionalText;
        }

        public void Show()
        {

            /*Dictionary<MenuOptions, string> menuOptionsDictionary = new Dictionary<MenuOptions, string>();
            menuOptionsDictionary.Add(MenuOptions.NewGame, "New Game");
            menuOptionsDictionary.Add(MenuOptions.Exit, "Exit");*/

            string header = GetHeader(HeaderText);

            Console.WriteLine(header);

            /*while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.Clear();

                string menuString = header + "\n\n";

                foreach (KeyValuePair<MenuOptions, string> pair in menuOptionsDictionary)
                {
                    if (pair.Key == menuOptions) menuString += $"\n> {pair.Value} <\n\n";
                    else menuString += $"  {pair.Value}  \n";
                }

                Console.WriteLine(menuString);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow: MoveMenuOptionsEnum(-1); break;
                    case ConsoleKey.DownArrow: MoveMenuOptionsEnum(+1); break;
                    case ConsoleKey.Enter: MenuAction(menuOptions); break;
                    default: break;
                }
            }*/

        }

        /*public void MoveMenuOptionsEnum(int i)
        {
            int numOptions = Enum.GetNames(typeof(MenuOptions)).Length;
            menuOptions = (MenuOptions)(((int)menuOptions + i + numOptions) % numOptions);
        }*/

        public string GetHeader(string text)
        {
            string topFrame = "╔";
            string mediumFrame = "║";
            string lowFrame = "╚";

            //string[] parts = text.Split('\n');

            foreach (char letter in text)
            {
                topFrame += "═";
                lowFrame += "═";
            }

            topFrame += "╗";
            mediumFrame += $"{text}║";
            lowFrame += "╝";

            return $"{topFrame}\n{mediumFrame}\n{lowFrame}";
        }

        /*public void MenuAction(MenuOptions menuOption)
        {
            switch (menuOption)
            {
                case MenuOptions.Exit: Environment.Exit(0); break;
                case MenuOptions.NewGame: NewGame(); break;
                default: break;
            }
        }

        public void NewGame()
        {
            Console.Clear();

            gameSession = new Game(100, 20);
            gameSession.BackToMenu += BackToMenu;
            gameSession.Run();
        }

        public void BackToMenu()
        {
            Console.Clear();
            Show();
            return;
        }*/
    }
}
