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

        public char GetFrameSignOn(int x, int y, int maxWidth, int maxHeight)
        {
            bool isTopLeftCorner = x == 0 && y == 0;
            bool isTopRightCorner = x == maxWidth && y == 0;
            bool isBottomLeftCorner = x == 0 && y == maxHeight;
            bool isBottomRightCorner = x == maxWidth && y == maxHeight;
            bool isVerticalBorder = x == 0 || x == maxWidth;
            bool isHorizontalBorder = y == 0 || y == maxHeight;

            if (isTopLeftCorner) return TopLeftCorner;
            else if (isTopRightCorner) return TopRightCorner;
            else if (isBottomLeftCorner) return BottomLeftCorner;
            else if (isBottomRightCorner) return BottomRightCorner;
            else if (isHorizontalBorder) return HorizontalBorder;
            else if (isVerticalBorder) return VerticalBorder;

            throw new Exception("There is not sign on that position.");
        }

    }
}
