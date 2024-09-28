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
    public partial class Form1 : Form
    {
        private const int maxSnowfleaks = 40;
        private Snowfleak[] snowfleaks = new Snowfleak[maxSnowfleaks];
        private Timer timer;
        private Random rand;
        private Graphics g;
        private Image backImage;
        private int lastIndex = 0;
        private int nextWayv = 0;
        public Form1()
        {
            InitializeComponent();
            backImage = ResizeImage(Properties.Resources.backgraund, this.Width, this.Height);

            g = this.CreateGraphics();
            this.rand = new Random();
            CreatSnowfleaks(10);

            
            this.timer = new Timer();
            this.timer.Interval = 30; 
            this.timer.Tick += new EventHandler(this.TimerTick);
            this.timer.Start();

            
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
            var newImg = new Bitmap(this.Width, this.Height);
            var gr = Graphics.FromImage(newImg);
            gr.DrawImage(backImage, 0, 0, this.Width,this.Height);
            for (int i = 0; i < lastIndex; i++)
            {
                gr.DrawImage(snowfleaks[i].image, new Rectangle(snowfleaks[i].posX, snowfleaks[i].posY, snowfleaks[i].size, snowfleaks[i].size));
                snowfleaks[i].move();
            }
            
            if (nextWayv % 100 == 0)
            {
                CreatSnowfleaks(10);
            }
            g.DrawImage(newImg, 0, 0);
        }

        private void CreatSnowfleaks(int num)
        {
            int posX;
            int posY;
            int size;

            if (lastIndex >= maxSnowfleaks) return;
            for (int i = 0; i < num; i++)
            {
                posX = rand.Next(1, this.ClientRectangle.Width);
                posY = rand.Next(-500, -100);
                size = rand.Next(30, 150);
                snowfleaks[lastIndex] = new Snowfleak(posX,posY, size);
                lastIndex++;
            }

        }
    }
}
