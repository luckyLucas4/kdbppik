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
        public bool penActive;
        public Shape currentShape;
        public Pen currentPen;
        public Bitmap bitmap;

        private Point startPos;
        private Point currentPos;
        private bool drawing;
        private List<Shape> shapes = new List<Shape>();
        private FreehandTool pen = new FreehandTool();
        

        public DrawingPanel(Pen startingPen,  Point position, Size size)
        {
            penActive = true;
            currentShape = new RectangleShape(startingPen.Color, startingPen.Width, new Rectangle());
            currentPen = startingPen;
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

            if(penActive)
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

            if(penActive)
            {
                if (pen.draw)
                {
                    Graphics graphics = Graphics.FromImage(bitmap);
                    
                    Pen paintingPen = currentPen;

                    paintingPen.EndCap = LineCap.Round;
                    paintingPen.StartCap = LineCap.Round;

                    graphics.DrawLine(paintingPen, pen.position.X , pen.position.Y, e.X, e.Y);
                }

                pen.position.X = e.X;
                pen.position.Y = e.Y;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            drawing = false;
            currentPos = e.Location;

            if (penActive)
                pen.draw = false;

            else if (currentShape is LineShape)
                AddLine();

            else if (currentShape is RectangleShape)
                AddRectangle();

            else if (currentShape is CircleShape)
                AddCircle();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            //drawing = false;
        }

        private void AddLine()
        {
           
            if (startPos.X - currentPos.X !=0 || startPos.Y - currentPos.Y !=0)
            {
                shapes.Add(new LineShape(currentPen.Color, currentPen.Width, startPos, currentPos));
                
            }
            this.Invalidate();
        }

        private void AddRectangle()
        {
            var rc = GetRectangle();

            if (rc.Width > 0 & rc.Height > 0)
            {
                shapes.Add(new RectangleShape(currentPen.Color, currentPen.Width, rc));
            }

            this.Invalidate(); // Rita om fönstret
        }

        private void AddCircle()
        {
            var rc = GetRectangle();

            if (rc.Width > 0 & rc.Height > 0)
            {
                shapes.Add(new CircleShape(currentPen.Color, currentPen.Width, rc));
            }

            this.Invalidate(); // Rita om fönstret
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = Graphics.FromImage(bitmap);

            e.Graphics.DrawImageUnscaled(bitmap, new Point(0, 0));

            if (shapes.Count > 0)
            {
                foreach (Shape s in shapes)
                {
                    if (s is RectangleShape)
                    {
                        e.Graphics.DrawRectangle(new Pen(s.color, s.borderWidth), s.Rect);
                        graphics.DrawRectangle(new Pen(s.color, s.borderWidth), s.Rect);
                    }
                    else if (s is CircleShape)
                    {
                        e.Graphics.DrawEllipse(new Pen(s.color, s.borderWidth), s.Rect);
                        graphics.DrawEllipse(new Pen(s.color, s.borderWidth), s.Rect);
                    }
                    else if (s is LineShape)
                    {
                        e.Graphics.DrawLine(new Pen(s.color, s.borderWidth), s.startPoint, s.endPoint);
                    }
                }
            }

            if (drawing && penActive == false)
            {
                if (currentShape is RectangleShape)
                    e.Graphics.DrawRectangle(Pens.Red, GetRectangle());

                else if (currentShape is CircleShape)
                    e.Graphics.DrawEllipse(Pens.Red, GetRectangle());

                else if (currentShape is LineShape)
                {
                    e.Graphics.DrawLine(Pens.Red, startPos, currentPos);
                }
            }   
        }
        public void SaveDrawing()
        {
            bitmap.Save("c:\\myBitmap.bmp");
        }
        
    }
}
