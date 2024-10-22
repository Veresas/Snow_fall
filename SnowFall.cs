using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snow_fall
{
    internal class SnowFall
    {
        Random random = new Random();

        /// <summary>
        /// Коллекция снежинок
        /// </summary>
        public List<Snowfleak> snowfleaks = new List<Snowfleak>();
        private const int MaxSnowfleakCount = 100;

        /// <summary>
        /// Текстира для снежинки
        /// </summary>
        public Texture2D Texture { get; private set; }

        /// <summary>
        /// Создание снегопада
        /// </summary>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="snow"></param>
        public void CreatSnowfleakList(int Width, int Height, Texture2D snow)
        {
            for (int i = 0; i < MaxSnowfleakCount; i++)
            {
                var size = random.Next(10, 100);
                var startPosition = new Point(random.Next(-30, Width), random.Next(-700, 0));

                snowfleaks.Add(new Snowfleak(snow, startPosition, size));
            }
        }

        /// <summary>
        /// Движение снежинок по экрану
        /// </summary>
        public void Move()
        {
            foreach (var s in snowfleaks)
            {
                s.Pos = new Point(s.Pos.X, s.Pos.Y + Constants.SpeedFalling);
                if (s.Pos.Y > Constants.WindowHeight + 30)
                {
                    s.Pos = new Point(random.Next(-30, Constants.WindowWidth), -s.Size);
                }
            }
        }
    }
}
