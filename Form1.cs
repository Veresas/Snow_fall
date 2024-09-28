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
        private int lastIndex = 0;
        private int nextWayv = 0;
        public Form1()
        {
            InitializeComponent();
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackgroundImage = Properties.Resources.backgraund;
            
            this.rand = new Random();
            CreatSnowfleaks(40);

            this.timer = new Timer();
            this.timer.Interval = 30; 
            this.timer.Tick += new EventHandler(this.TimerTick);
            this.timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            for(int i = 0; i < lastIndex; i++)
            {
                snowfleaks[i].move(snowfleaks[i].Location.X, snowfleaks[i].Location.Y);
            }

            /*nextWayv++;
            
            if(nextWayv%100 ==0)
            {
                CreatSnowfleaks(10);
            }*/
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
                posY = rand.Next(-500, -200);
                size = rand.Next(30, 150);
                snowfleaks[lastIndex] = new Snowfleak(posX,posY, size);
                this.Controls.Add(snowfleaks[lastIndex]);
                lastIndex++;
            }

        }
    }
}
