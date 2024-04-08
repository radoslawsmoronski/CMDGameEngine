using CMDGameEngine.GameObjects;
using CMDGameEngine.GameObjects.VisualMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDSupportProject
{
    public class Bird : GameObject
    {
        public bool IsBirdAction { get; private set; } = false;

        public Bird(int x, int y, VisualMap? visualMap) : base(x, y, visualMap)
        {

        }

        public void Jump()
        {
            if (IsBirdAction) return;

            Thread simulateJump = new Thread(SimulateJump);
            simulateJump.Start();
        }

        private void SimulateJump()
        {
            IsBirdAction = true;

            this.Move(0, -1);

            Thread.Sleep(50);

            this.Move(0, -1);

            Thread.Sleep(50);

            this.Move(0, -1);

            IsBirdAction = false;
        }
    }
}
