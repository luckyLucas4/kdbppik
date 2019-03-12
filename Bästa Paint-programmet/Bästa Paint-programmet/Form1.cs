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
        public Color color;     //väljer färg till currentPen
        DrawingPanel panel;

        public Form1()
        {
            InitializeComponent();

            panel = new DrawingPanel(new Pen(Color.Green, 10), panel1.Location, panel1.Size);
            Controls.Add(panel);
            panel1.Visible = false;
            panel1.Enabled = false;

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
        private void rbtnCirkel_CheckedChanged(object sender, EventArgs e)
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
            panel.currentPen.Color = color;
        }

        private void numWidth_ValueChanged(object sender, EventArgs e)
        {
            panel.currentPen.Width = (float)numWidth.Value;
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            panel.removeChange();

        }

        private void chbFill_CheckedChanged(object sender, EventArgs e)
        {
            panel.fillShape = chbFill.Checked;
        }
    }
}
