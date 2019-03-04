﻿using System;
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
        private List<Shape> shapes = new List<Shape>();
        private FreehandTool pen = new FreehandTool();
        private bool penActive;
        public Shape currentShape;
        public Pen currentPen;

        public DrawingPanel(Pen startingPen,  Point position, Size size)
        {
            penActive = true;
            currentShape = new RectangleShape(startingPen, new Rectangle());
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
            var rc = GetRectangle();

            if (penActive)
                pen.draw = false;

            else if (currentShape is RectangleShape)
                AddRectangle(e);

            else if (currentShape is CircleShape)
                AddCircle(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            drawing = false;
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
                    shapes.Add(new RectangleShape(currentPen, rc));
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
                    shapes.Add(new CircleShape(currentPen, rc));
                }

                this.Invalidate(); // Rita om fönstret
            }
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
                        e.Graphics.DrawRectangle(s.pen, s.rect);
                        graphics.DrawRectangle(s.pen, s.rect);
                    }
                    else if (s is CircleShape)
                    {
                        e.Graphics.DrawEllipse(Pens.Black, s.rect);
                        graphics.DrawEllipse(Pens.Black, s.rect);
                    }
                    else if (s is LineShape)
                    {
                        e.Graphics.DrawLine(s.pen, s.startPoint, s.endPoint);
                        graphics.DrawLine(s.pen, s.startPoint, s.endPoint);
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
                    e.Graphics.DrawLine(Pens.Red, currentShape.startPoint, currentShape.endPoint);
                }
            }   
        }
        public void SaveDrawing()
        {
            bitmap.Save("c:\\myBitmap.bmp");
        }
        
    }
}
