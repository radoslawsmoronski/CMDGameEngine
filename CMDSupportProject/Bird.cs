using CMDGameEngine.Objects;
using CMDGameEngine.Objects.VisualMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDSupportProject
{
    public class Bird : GameObject
    {
        VisualMap visualMapFlying;
        VisualMap visualMapFalling;

        public bool IsBirdAction { get; private set; } = false;

        public Bird(int x, int y, VisualMap? visualMap) : base(x, y, visualMap)
        {
            visualMapFlying = new VisualMap("bird1.xml");
            visualMapFalling = new VisualMap("bird2.xml");

            Thread birdPhysics = new Thread(SimulateBirdPhysics);
            birdPhysics.Start();
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

            this.ChangeVisualMap(visualMapFlying);
            Thread.Sleep(75);
            Console.Beep(750, 75);

            this.Move(0, -2);
            this.ChangeVisualMap(visualMapFalling);

            this.ChangeVisualMap(visualMapFlying);
            Thread.Sleep(75);
            Console.Beep(650, 75);

            this.Move(0, -2);
            this.ChangeVisualMap(visualMapFalling);


            IsBirdAction = false;
        }

        private void SimulateBirdPhysics()
        {
            while (true)
            {
                if (IsBirdAction)
                {
                    continue;
                }

                Thread.Sleep(150);
                this.Move(0, +1);
                Thread.Sleep(150);
                this.Move(0, +1);
            }
        }
    }
}
