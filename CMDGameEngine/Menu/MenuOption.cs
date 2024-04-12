using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Menu Option for GameMenu 

namespace CMDGameEngine.Menu
{
    public class MenuOption
    {
        public int Id { get; private set; }
        public string Text { get; private set; }
        public Action Action { get; private set; }

        public MenuOption(string optionText, Action action)
        {
            if (optionText == null) throw new ArgumentNullException(nameof(optionText));
            else if (action == null) throw new ArgumentNullException(nameof(action));

            Text = optionText;
            Action = action;
        }
    }
}
