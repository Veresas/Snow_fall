using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snow_fall
{
    internal class Snowfleak
    {
        private Random rand = new Random();
        public int PosX { get; private set; }
        public int PosY { get; private set; }
        public int Size { get; private set; }
        public Image image = Properties.Resources.snow;
        public Snowfleak(int x, int y, int size)
        {
            PosX = x;
            PosY = y;
            Size = size;
        }

        public void move(int h)
        {
            PosY++;
            if (PosY == h)
            {
                PosY = -100;
                PosX = rand.Next(1, 600);
            }
        }
    }
}
