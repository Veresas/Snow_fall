using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snow_fall
{
    internal class Snowfleak
    {
        private Random rand = new Random();
        public Texture2D Texture { get; private set; }
        public Point Pos { get; set; }
        public int Size { get; private set; }

        public Snowfleak(Texture2D texture, Point pos, int size)
        {
            Texture = texture;
            Pos = pos;
            Size = size;
        }
    }
}
