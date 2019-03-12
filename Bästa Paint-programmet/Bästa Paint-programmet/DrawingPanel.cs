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
        public bool fillShape;
        public Shape currentShape;
        public Pen currentPen;
        public Bitmap bitmap;

        private Point startPos;
        private Point currentPos;
        private bool drawing;
        private List<Bitmap> bitmapHistory = new List<Bitmap>();
        private List<Bitmap> undoHistory = new List<Bitmap>();
        private FreehandTool freehand = new FreehandTool();


        public DrawingPanel(Pen startingPen, Point position, Size size)
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
            bitmapHistory.Add(new Bitmap(bitmap));
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

            if (penActive)
            {
                freehand.draw = true;

                freehand.position.X = e.X;
                freehand.position.Y = e.Y;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            currentPos = e.Location;
            if (drawing)
            {
                this.Invalidate();
            }

            if (penActive)
            {
                if (freehand.draw)
                {
                    Graphics graphics = Graphics.FromImage(bitmap);

                    Pen paintingPen = currentPen;

                    paintingPen.EndCap = LineCap.Round;
                    paintingPen.StartCap = LineCap.Round;

                    graphics.DrawLine(paintingPen, freehand.position.X, freehand.position.Y, e.X, e.Y);
                }

                freehand.position.X = e.X;
                freehand.position.Y = e.Y;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            drawing = false;
            currentPos = e.Location;
            Graphics g = Graphics.FromImage(bitmap);

            if (penActive)
                freehand.draw = false;

            else if (currentShape is LineShape)
                AddLine(g);

            else if (currentShape is RectangleShape)
                AddRectangle(g);

            else if (currentShape is CircleShape)
                AddCircle(g);

            bitmapHistory.Add(new Bitmap(bitmap));
        }

        private void AddLine(Graphics g)
        {
            
            if (startPos.X - currentPos.X !=0 || startPos.Y - currentPos.Y !=0)
            {
                g.DrawLine(currentPen, startPos, currentPos);
            }
            this.Invalidate(); // Rita om fönstret
        }

        private void AddRectangle(Graphics g)
        {
            var rc = GetRectangle();

            if (rc.Width > 0 & rc.Height > 0)
            {
                if (fillShape)
                    g.FillRectangle(new SolidBrush(currentPen.Color), rc);
                else
                    g.DrawRectangle(currentPen, rc);
            }

            this.Invalidate(); // Rita om fönstret
        }

        private void AddCircle(Graphics g)
        {
            var rc = GetRectangle();

            if (rc.Width > 0 & rc.Height > 0)
            {
                if (fillShape)
                    g.FillEllipse(new SolidBrush(currentPen.Color), rc);
                else
                    g.DrawEllipse(currentPen, rc);
            }

            this.Invalidate(); // Rita om fönstret
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = Graphics.FromImage(bitmap);

            e.Graphics.DrawImageUnscaled(bitmap, new Point(0, 0));

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

        public void UndoChange()
        {
            if(bitmapHistory.Count > 1)
            {
                undoHistory.Add(bitmapHistory[bitmapHistory.Count - 1]);
                bitmapHistory.RemoveAt(bitmapHistory.Count - 1);
                bitmap = new Bitmap(bitmapHistory[bitmapHistory.Count - 1]);
                this.Invalidate();
            }
        }

        public void RedoChange()
        {
            if(undoHistory.Count > 0)
            {
                bitmapHistory.Add(undoHistory[undoHistory.Count - 1]);
                undoHistory.RemoveAt(undoHistory.Count - 1);
                bitmap = new Bitmap(bitmapHistory[bitmapHistory.Count - 1]);
                this.Invalidate();
            }
        }
    }
}
