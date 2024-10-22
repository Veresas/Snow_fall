using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snow_fall
{
    internal class SnowFall
    {
        Random random = new Random();
        public List<Snowfleak> snowfleaks = new List<Snowfleak>();
        private const int MaxSnowfleakCount = 100;
        public Texture2D Texture { get; private set; }

        public void CreatSnowfleakList(int Width, int Height, Texture2D snow)
        {
            for (int i = 0; i < MaxSnowfleakCount; i++)
            {
                var size = random.Next(10, 100);
                var startPosition = new Point(random.Next(-30, Width), random.Next(-700, 0));

                snowfleaks.Add(new Snowfleak(snow, startPosition, size));
            }
        }
        public void Move()
        {
            foreach (var s in snowfleaks)
            {
                s.Pos = new Point(s.Pos.X, s.Pos.Y + 2);
                if (s.Pos.Y > Constants.WindowHeight + 30)
                {
                    s.Pos = new Point(random.Next(-30, Constants.WindowWidth), -s.Size);
                }
            }
        }
    }
}
