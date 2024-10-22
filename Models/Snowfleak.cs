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

        /// <summary>
        /// Текстура снежинки
        /// </summary>
        public Texture2D Texture { get; private set; }

        /// <summary>
        /// Позиция снежинки на экране
        /// </summary>
        public Point Pos { get; set; }

        /// <summary>
        /// Размер снежинки
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Установка значений снежинки при создании
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="pos"></param>
        /// <param name="size"></param>
        public Snowfleak(Texture2D texture, Point pos, int size)
        {
            Texture = texture;
            Pos = pos;
            Size = size;
        }
    }
}
