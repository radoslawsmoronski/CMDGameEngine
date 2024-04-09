using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMDGameEngine.GameObjects;
using CMDGameEngine.GameObjects.VisualMap;

namespace CMDSupportProject
{
    public class Block : GameObject
    {
        public int CurrentScene { get; set; } = 0;
        public Block(int x, int y, VisualMap? visualMap) : base(x, y, visualMap)
        {
        }
    }
}
