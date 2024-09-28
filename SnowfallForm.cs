using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snow_fall
{
    public partial class SnowfallForm : Form
    {
        private const int MaxSnowfleaks = 40;
        private Snowfleak[] snowfleaks = new Snowfleak[MaxSnowfleaks];
        private Graphics g;
        private Image backImage;
        private int lastIndex = 0;
        private int nextWayv = 0;
        public SnowfallForm()
        {
            InitializeComponent();
            backImage = ResizeImage(Properties.Resources.backgraund, Width, Height);

            g = CreateGraphics();
            CreatSnowfleaks(10);
            InitTimer();
        }

        private void InitTimer()
        {
            Timer timer = new Timer();
            timer.Interval = 30;
            timer.Tick += new EventHandler(TimerTick);
            timer.Start();
        }
        private Image ResizeImage(Image image, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(bmp))
            {
                graphics.DrawImage(image, 0, 0, width, height);
            }
            return bmp;
        }
        private void TimerTick(object sender, EventArgs e)
        {
            var newImg = new Bitmap(Width, Height);
            var gr = Graphics.FromImage(newImg);
            gr.DrawImage(backImage, 0, 0, Width, Height);
            for (int i = 0; i < lastIndex; i++)
            {
                gr.DrawImage(snowfleaks[i].image, new Rectangle(snowfleaks[i].PosX, snowfleaks[i].PosY, snowfleaks[i].Size, snowfleaks[i].Size));
                snowfleaks[i].move(Height);
            }

            if (nextWayv % 100 == 0)
            {
                CreatSnowfleaks(10);
            }
            g.DrawImage(newImg, 0, 0);
        }

        private void CreatSnowfleaks(int num)
        {
            Random rand = new Random();
            int posX;
            int posY;
            int size;

            if (lastIndex >= MaxSnowfleaks)
            {
                return;
            }

            for (int i = 0; i < num; i++)
            {
                posX = rand.Next(1, 600);
                posY = rand.Next(-500, -100);
                size = rand.Next(30, 150);
                snowfleaks[lastIndex] = new Snowfleak(posX, posY, size);
                lastIndex++;
            }

        }
    }
}
