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
        public Bitmap bitmap;
        private List<Rectangle> rectangles = new List<Rectangle>();
        private List<Rectangle> ellipses = new List<Rectangle>();
        private DrawingPen pen = new DrawingPen();

        public string currentShape;

        public DrawingPanel(string shape, Point position, Size size)
        {
            currentShape = shape;
            BackColor = Color.White;
            this.Location = position;
            this.Size = size;
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);
            bitmap = new Bitmap(this.Width, this.Height, this.CreateGraphics());
            Graphics.FromImage(bitmap).Clear(Color.White);
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
                pen.draw = true;

                pen.position.X = e.X;
                pen.position.Y = e.Y;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            currentPos = e.Location;
            if (drawing)
            {
                this.Invalidate();
            }

            if(currentShape == "pen")
            {
                if (pen.draw)
                {
                    Graphics graphics = Graphics.FromImage(bitmap);

                    Pen paintingPen = new Pen(Color.Black, 10);

                    paintingPen.EndCap = LineCap.Round;
                    paintingPen.StartCap = LineCap.Round;

                    graphics.DrawLine(paintingPen, pen.position.X , pen.position.Y, e.X, e.Y);

                    this.CreateGraphics().DrawImageUnscaled(bitmap, new Point(0, 0));
                }

                pen.position.X = e.X;
                pen.position.Y = e.Y;
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
                    pen.draw = false;
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

            if(currentShape == "pen")
            {
                e.Graphics.DrawImageUnscaled(bitmap, new Point(0, 0));
            }
        }
    }
}
