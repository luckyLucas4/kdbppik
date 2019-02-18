using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Bästa_Paint_programmet
{
    class DrawingPanel : Panel
    {
        private Point startPos;
        private Point currentPos;
        private bool drawing;
        private List<Rectangle> rectangles = new List<Rectangle>();
        private List<Rectangle> ellipses = new List<Rectangle>();
        private DrawingPen pen = new DrawingPen();

        public string currentShape;

        public DrawingPanel(string shape, Point position)
        {
            currentShape = shape;
            BackColor = Color.White;
            this.Location = position;
            this.Size = new Size(200, 200);
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        public DrawingPanel(string shape, Point position, Size size)
        {
            currentShape = shape;
            BackColor = Color.White;
            this.Location = position;
            this.Size = size;
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        protected Rectangle GetRectangle()
        {
            return new Rectangle(
                Math.Min(startPos.X, currentPos.X),
                Math.Min(startPos.Y, currentPos.Y),
                Math.Abs(startPos.X - currentPos.X),
                Math.Abs(startPos.Y - currentPos.Y)
                );
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            currentPos = startPos = e.Location;
            drawing = true;

            if(currentShape == "pen")
            {

            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            currentPos = e.Location;
            if (drawing)
            {
                this.Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            switch (currentShape)
            {
                case "rectangle":
                    AddRectangle(e);
                    break;

                case "circle":
                    AddCircle(e);
                    break;

                case "pen":
                    break;


            }
        }

        private void AddRectangle(MouseEventArgs e)
        {
            if (drawing)
            {
                drawing = false;
                currentPos = e.Location;
                var rc = GetRectangle();

                if (rc.Width > 0 & rc.Height > 0)
                {
                    rectangles.Add(rc);
                }

                this.Invalidate(); // Rita om fönstret
            }
        }

        private void AddCircle(MouseEventArgs e)
        {
            if (drawing)
            {
                drawing = false;
                currentPos = e.Location;
                var rc = GetRectangle();

                if (rc.Width > 0 & rc.Height > 0)
                {
                    ellipses.Add(rc);
                }

                this.Invalidate(); // Rita om fönstret
            }
        }

        private void AddPen(MouseEventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (rectangles.Count > 0)
            {
                e.Graphics.DrawRectangles(Pens.Black, rectangles.ToArray());
            }

            if (ellipses.Count > 0)
            {
                foreach (Rectangle r in ellipses)
                {
                    e.Graphics.DrawEllipse(Pens.Black, r);
                }
            }

            if (drawing)
            {
                switch (currentShape)
                {
                    case "rectangle":
                        e.Graphics.DrawRectangle(Pens.Red, GetRectangle());
                        break;

                    case "circle":
                        e.Graphics.DrawEllipse(Pens.Red, GetRectangle());
                        break;

                }  
            }
        }
    }
}
