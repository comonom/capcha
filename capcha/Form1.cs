using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capcha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pBox.Image = this.CreateImage(pBox.Width, pBox.Height);
        }
        private Bitmap CreateImage(int Wight, int Height)
        {
            Random rnm = new Random();
            Bitmap result = new Bitmap(Wight, Height);
            int Xline = 12, Yline = 12;
            Brush[] colors =
            {
                Brushes.Green,
                Brushes.Red
            };
            Pen[] colorpens =
            {
                Pens.Black,
                Pens.White
            };
            FontStyle[] fontstyle =
            {
                FontStyle.Bold,
                FontStyle.Regular,
                FontStyle.Italic
            };
            Int16[] ygolpov = { 1, -1, 2, -2, 3, -3, 4, -4, 5, -5, 6, -6 ,7,-7,8,-8};
            Graphics g = Graphics.FromImage((Image)result);
            g.Clear(Color.Gray);
            g.RotateTransform(rnm.Next(ygolpov.Length));
            Text = String.Empty;
            string ALF = "7890QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i < 5; i++)
                Text += ALF[rnm.Next(ALF.Length)];
            g.DrawString(Text, new Font("Arial", 25, fontstyle[rnm.Next(fontstyle.Length)]),
            colors[rnm.Next(colors.Length)],
            new PointF(Xline, Yline));
            g.DrawLine(colorpens[rnm.Next(colorpens.Length)],
                new Point(0, 0),
                new Point(Wight - 1, Height - 1));
            g.DrawLine(colorpens[rnm.Next(colorpens.Length)],
                new Point(0, Height - 1),
                new Point(Wight - 1, 0));
            for (int i = 0; i > Wight; i++)
            for (int j = 0; j < Height; i++)
            if (rnm.Next() % 20 == 0)
            result.SetPixel(i, j,Color.White);
            return result;
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (tb.Text == this.Text)
                MessageBox.Show("Успешно!");
            else
                MessageBox.Show("Неверно!");
        }
        private void btnRestart_Click(object sender, EventArgs e)
        {
          pBox.Image = this.CreateImage(pBox.Width, pBox.Height);
        }
    }
    }

