using System;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

using CMDGameEngine.Additional;
using System.Reflection.PortableExecutable;

namespace CMDGameEngine.Menu
{
    public class GameMenu
    {
        List<MenuOption> menuOptions;
        private MenuOption currentChooseMenuOption;
        public string? HeaderText { get; private set; }
        public string? AdditionalText { get; private set; }
        public Frame HeaderFrame { get; private set; }

        public bool IsMenuOn { get; private set; }

        public GameMenu(string? headerText, string? additionalText)
        {
            HeaderText = headerText;
            AdditionalText = additionalText;

            HeaderFrame = new Frame();
        }

        public void AddMenuOptions(List<MenuOption> menuOptions)
        {
            this.menuOptions = menuOptions;
            currentChooseMenuOption = this.menuOptions[0];
        }

        public void Show()
        {
            if(menuOptions == null) throw new ArgumentNullException(nameof(menuOptions));

            IsMenuOn = true;

            while (IsMenuOn)
            {
                Console.SetCursorPosition(0, 0);

                string menuString = "";

                if (HeaderText != null)
                {
                    string header = GetHeader(HeaderText);
                    menuString += header;
                }

                if (AdditionalText != null)
                {
                    menuString += "\n" + AdditionalText + "\n";
                }

                menuString += "\n";

                foreach (MenuOption menuOption in menuOptions)
                {
                    if (menuOption == currentChooseMenuOption)
                    {
                        menuString += $"\n  > {menuOption.Text} <\n\n";
                    }
                    else
                    {
                        menuString += $"  {menuOption.Text}\n";
                    }
                }

                Console.Clear();
                Console.WriteLine(menuString);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow: MoveMenuOptions(-1); break;
                    case ConsoleKey.DownArrow: MoveMenuOptions(+1); break;
                    case ConsoleKey.Enter: currentChooseMenuOption.Action(); break;
                    default: break;
                }
            }

        }

        public void MoveMenuOptions(int i)
        {
            int numOptions = menuOptions.Count;
            int currentIndex = menuOptions.IndexOf(currentChooseMenuOption);
            int newIndex = (currentIndex + i + numOptions) % numOptions;
            currentChooseMenuOption = menuOptions[newIndex];
        }

        public string GetHeader(string text)
        {
            string[] lines = text.Split('\n');
            int headerHeight = lines.Length;
            int headerWidth = StringPartsAnalyzer.GetLengthOfTheLongestPart(lines);

            StringBuilder buffer = new StringBuilder();

            buffer.Append("\n");

            foreach (var lineIndex in Enumerable.Range(-1, headerHeight + 2))
            {
                buffer.Append("  ");
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

        public void CloseMenu()
        {
            IsMenuOn = false;
            Console.Clear();
        }

        private string GetLeftSpacesMargin(int containerWidth, int elementInWidth)
        {
            string leftSpacesMargin = "";

            int amountIteration = (containerWidth - elementInWidth) / 2;

            for (int i = 0; i < amountIteration; i++)
            {
                leftSpacesMargin += " ";
            }

            return leftSpacesMargin;
        }
    }
}
