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
        PictureBox pictureBox = new PictureBox();
        private Timer timer;
        public Form1()
        {
            InitializeComponent();

            pictureBox.Image = Properties.Resources.snow;
            pictureBox.Location = new System.Drawing.Point(1,1);
            pictureBox.Visible = true;
            pictureBox.Size = new System.Drawing.Size(100, 100);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pictureBox);


            this.timer = new Timer();
            this.timer.Interval = 1000; // Интервал в миллисекундах (в данном случае 1 секунда)
            this.timer.Tick += new EventHandler(this.timer_Tick);
            this.timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            int i = 0;
            while (true)
            {
                i = 0;
                while (i < 10000000)
                {
                    i++;
                }
                pictureBox.Location = new System.Drawing.Point(pictureBox.Location.X, pictureBox.Location.Y + 1);

            }
        }
    }
}
