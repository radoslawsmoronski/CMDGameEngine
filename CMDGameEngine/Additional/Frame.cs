using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDGameEngine.Additional
{
    public class Frame
    {
        public char TopLeftCorner { get; set; } = '╔';
        public char TopRightCorner { get; set; } = '╗';
        public char BottomLeftCorner { get; set; } = '╚';
        public char BottomRightCorner { get; set; } = '╝';
        public char HorizontalBorder { get; set; } = '═';
        public char VerticalBorder { get; set; } = '║';

    }
}
