using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Bästa_Paint_programmet
{
    public partial class Form1 : Form
    {
        bool draw = false;

        DrawingPanel panel;

        int pX = -1;
        int pY = -1;

        Bitmap drawing;

        public Form1()
        {
            InitializeComponent();

            panel = new DrawingPanel("circle", panel1.Location, panel1.Size);
            Controls.Add(panel);
            panel1.Visible = false;
            panel1.Enabled = false;

            drawing = new Bitmap(panel.Width, panel.Height, panel.CreateGraphics());
            Graphics.FromImage(drawing).Clear(Color.White);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            draw = true;

            pX = e.X;
            pY = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (draw)
            {
                Graphics panel = Graphics.FromImage(drawing);

                Pen pen = new Pen(Color.Black, 10);

                pen.EndCap = LineCap.Round;
                pen.StartCap = LineCap.Round;

                panel.DrawLine(pen, pX, pY, e.X, e.Y);

                panel1.CreateGraphics().DrawImageUnscaled(drawing, new Point(0, 0));
            }

            pX = e.X;
            pY = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            draw = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(drawing, new Point(0, 0));
        }

        private void Cirkel_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
