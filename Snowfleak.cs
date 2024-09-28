using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snow_fall
{
    internal class Snowfleak : PictureBox
    {
        public Snowfleak(int x, int y, int size)
        {
            Image = Properties.Resources.snow2;
            BackColor = Color.Transparent;
            Location = new System.Drawing.Point(x, y);
            Visible = true;
            Size = new System.Drawing.Size(size, size);
            SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void move(int x, int y)
        {
            Location = new System.Drawing.Point(x, y+1);
        }

        
    }
}
