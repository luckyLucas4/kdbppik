﻿using System;
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
        public Color color;     //väljer färg till currentPen
        DrawingPanel panel;

        int pX = -1;
        int pY = -1;

        public Bitmap drawing;

        public Form1()
        {
            InitializeComponent();

            panel = new DrawingPanel(new Pen(Color.Green, 10), panel1.Location, panel1.Size);
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
      
      
        public void ToolCheck()
        {
            if (rBtnPenna.Checked == true)
            {
                panel.penActive = true;
            }
            else
            {
                panel.penActive = false;
            }
            if (rBtnLinje.Checked == true)
            {
                panel.currentShape = new LineShape();
            }
            if (rBtnRektangel.Checked == true)
            {
                panel.currentShape = new RectangleShape();
            }
            if (rBtnCirkel.Checked == true)
            {
                panel.currentShape = new CircleShape();
            }
        }
        private void Cirkel_CheckedChanged(object sender, EventArgs e)
        {
            ToolCheck();
        }

        private void rBtnRektangel_CheckedChanged(object sender, EventArgs e)
        {
            ToolCheck();
        }

        private void rBtnLinje_CheckedChanged(object sender, EventArgs e)
        {
            ToolCheck();
        }

        private void rBtnPenna_CheckedChanged(object sender, EventArgs e)
        {
            ToolCheck();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                color = colorDialog1.Color;
            }
            btnColor.BackColor = color;
            panel.currentPen.Color = color;     //Nödlösning tror jag
        }

        private void numWidth_ValueChanged(object sender, EventArgs e)
        {
            panel.currentPen.Width = (float)numWidth.Value;
        }
    }
}
