using System;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

using CMDGameEngine.Additional;

namespace CMDGameEngine
{
    public class GameMenu
    {
        List<string> menuOptions;
        public string? HeaderText { get; private set; }
        public string? AdditionalText { get; private set; }
        public Frame HeaderFrame { get; private set; }

        public GameMenu(List<string> menuOptions, string? headerText, string? additionalText)
        {
            this.menuOptions = menuOptions;
            HeaderText = headerText;
            AdditionalText = additionalText;

            HeaderFrame = new Frame();
        }

        public void Show()
        {

            if (HeaderText != null)
            {
                string header = GetHeader(HeaderText);
                Console.WriteLine(header);
            }

            if (AdditionalText != null)
            {
                Console.WriteLine(AdditionalText);
            }

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
            string[] lines = text.Split('\n');
            int headerHeight = lines.Length;
            int headerWidth = StringPartsAnalyzer.GetLengthOfTheLongestPart(lines);

            StringBuilder buffer = new StringBuilder();

            foreach (var lineIndex in Enumerable.Range(-1, headerHeight + 2))
            {
                foreach (var charIndex in Enumerable.Range(-1, headerWidth + 2))
                {
                    bool isTopLeftCorner = charIndex == -1 && lineIndex == -1;
                    bool isTopRightCorner = charIndex == headerWidth && lineIndex == -1;
                    bool isBottomLeftCorner = charIndex == -1 && lineIndex == headerHeight;
                    bool isBottomRightCorner = charIndex == headerWidth && lineIndex == headerHeight;
                    bool isVerticalBorder = charIndex == -1 || charIndex == headerWidth;
                    bool isHorizontalBorder = lineIndex == -1 || lineIndex == headerHeight;

                    if (isTopLeftCorner) buffer.Append(HeaderFrame.TopLeftCorner);
                    else if (isTopRightCorner) buffer.Append(HeaderFrame.TopRightCorner);
                    else if (isBottomLeftCorner) buffer.Append(HeaderFrame.BottomLeftCorner);
                    else if (isBottomRightCorner) buffer.Append(HeaderFrame.BottomRightCorner);
                    else if (isHorizontalBorder) buffer.Append(HeaderFrame.HorizontalBorder);
                    else if (isVerticalBorder) buffer.Append(HeaderFrame.VerticalBorder);
                    else if (lineIndex >= 0 && lineIndex < lines.Length && charIndex >= 0 && charIndex < lines[lineIndex].Length)
                        buffer.Append(lines[lineIndex][charIndex]);
                    else
                        buffer.Append(" ");
                }
                buffer.AppendLine();
            }

            return buffer.ToString();
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
