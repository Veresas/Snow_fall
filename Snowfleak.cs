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
        public int posX { get; private set; }
        public int posY { get; private set; }
        public int size { get; private set; }
        public Image image = Properties.Resources.snow2;
        public Snowfleak(int x, int y, int size)
        {
            posX = x;
            posY = y;
            this.size = size;
        }

        public void move()
        {
            posY++;
        }

        
    }
}
