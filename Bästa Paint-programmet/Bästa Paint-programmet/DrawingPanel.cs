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
    // Ett objekt som kan användas som en ritbar panel
    class DrawingPanel : Panel
    {
        public bool freehandActive; // Är frihands-verktyget aktiverat?
        public bool fillShape;      // Ska formerna fyllas i?
        public Shape currentShape;  // Formen som ska ritas
        public Pen currentPen;      // Pennan som formen ska ritas med
        public Bitmap bitmap;       // Bitmapen som formerna ritas på 

        private Point startPos;     // Startpositionen när musen trycks ned
        private Point currentPos;   // Musenpekarens nuvarande position
        private bool drawing;       // Ritar användaren en ny figur?

        // De tidigare versionerna av bitmaps sparas i en lista
        private List<Bitmap> bitmapHistory = new List<Bitmap>();
        // Bitmaps som ångras sparas i en egen lista
        private List<Bitmap> undoHistory = new List<Bitmap>();

        // Sparar värden för frihandsverktyget
        private FreehandTool freehand = new FreehandTool();

        // Konstruktorn får in en penna som former ska ritas med, en position och en storlek
        public DrawingPanel(Pen startingPen, Point position, Size size)
        {
            freehandActive = true;      // Till en början är frihandsverktyget aktiverat
            BackColor = Color.White;    // Sätter bakrundsfärgen till vit
            this.Location = position;   // Flyttar panelen till position (positionen för den förra panelen)
            this.Size = size;           // Sätter storleken till size (storleken på den förra panelen)
            DoubleBuffered = true;      // En inställning som motverkar "flimmer" när skärmen uppdateras
            currentPen = startingPen;   // startingPen kopieras till currentPen

            // Pennan får rundade ändar
            currentPen.StartCap = LineCap.Round;
            currentPen.EndCap = LineCap.Round;   

            // En inställning som gör att panelen uppdateras när storleken ändras
            SetStyle(ControlStyles.ResizeRedraw, true); 

            // I currentShape sparas en ny RectangleShape
            currentShape = new RectangleShape(startingPen.Color, startingPen.Width, new Rectangle());

            // Skapar en ny bitmap som täcker panelen och länkar den till panelens Graphics
            bitmap = new Bitmap(this.Width, this.Height, this.CreateGraphics()); 

            Graphics.FromImage(bitmap).Clear(Color.White);  // Fyller bitmapen med vit färg
            bitmapHistory.Add(new Bitmap(bitmap));          // Lägger till bitmapen i historiken
        }

        // En funktion som skapar en ny rektangel mellan startPos och currentPos
        protected Rectangle GetRectangle()
        {
            return new Rectangle(
                Math.Min(startPos.X, currentPos.X),
                Math.Min(startPos.Y, currentPos.Y),
                Math.Abs(startPos.X - currentPos.X),
                Math.Abs(startPos.Y - currentPos.Y)
                );
        }

        // Aktiveras när musen trycks ner
        protected override void OnMouseDown(MouseEventArgs e)
        {
            // currentPos och startPos sätts till muspekarens position
            currentPos = startPos = e.Location;
            // Indikerar att en ny form ritas
            drawing = true;

            // Om frihandsverktyget är aktiverat
            if (freehandActive)
            {
                freehand.draw = true;   // Indikerar att frihandsverktyget används

                // Positionen i objektet freehand sätt till samma position som muspekaren
                freehand.position = e.Location;
            }
        }

        // Aktiveras när muspekaren flyttas
        protected override void OnMouseMove(MouseEventArgs e)
        {
            // currentPos sätts till muspekarens position
            currentPos = e.Location;

            // Om en ny form ritas så ska panelen ritas om
            if (drawing)
                this.Invalidate();

            // Om frihandsverktyget är aktiverat
            if (freehandActive)
            {
                // Om något ritas med frihandsverktyget
                if (freehand.draw)
                {
                    //Skapar ett Graphics objekt som länkas till bitmapen
                    Graphics graphics = Graphics.FromImage(bitmap); 

                    // Ritar en linje från frihandsverktygets förra position till muspekarens position
                    graphics.DrawLine(currentPen, freehand.position.X, freehand.position.Y, e.X, e.Y);
                }
                // Frihandsverktygets position sätts lika med muspekarens position
                freehand.position = e.Location;
            }
        }

        // Aktiveras när musknappen lyfts upp
        protected override void OnMouseUp(MouseEventArgs e)
        {
            drawing = false; // Indikerar att ingen form ritas
            currentPos = e.Location; // Sätter currentPos till muspekarens position
            Graphics g = Graphics.FromImage(bitmap); // Skapar ett Graphics objekt länkat till bitmapen

            // Om frihandsverktyget är aktivt 
            if (freehandActive)
                freehand.draw = false; // Indikerar att inget ritas med frihandsverktyget

            // Om currentShape är av typen LineShape, RectangleShape eller CircleShape 
            // aktiveras respektive funktion för att rita figuren
            else if (currentShape is LineShape)
                AddLine(g);
            else if (currentShape is RectangleShape)
                AddRectangle(g);
            else if (currentShape is CircleShape)
                AddCircle(g);

            bitmapHistory.Add(new Bitmap(bitmap)); // Lägger till den uppdaterade bitmapen i historiken
            this.Invalidate(); // Ritar om panelen
        }

        // Funktion som ritar en linje
        private void AddLine(Graphics g)
        {
            // Om det avståndet mellan startPos och currentPos är större än 0
            // i x- eller y-led
            if (startPos.X - currentPos.X != 0 || startPos.Y - currentPos.Y != 0)
            { 
                // Ritar en ny linje med currentPen från startPos till currentPos
                g.DrawLine(currentPen, startPos, currentPos);
            }
        }

        // Funktion för att rita en rektangel
        private void AddRectangle(Graphics g)
        {
            // Skapar en ny rektangel som utgår från currentPos och startPos
            var rc = GetRectangle();

            // Om rektangeln har höjd och bredd
            if (rc.Width > 0 & rc.Height > 0)
            {
                // Om fillShape är sant ritas en ifylld rektangel, 
                // annars ritas utkanten av en rektangel
                if (fillShape)
                    g.FillRectangle(new SolidBrush(currentPen.Color), rc);
                else
                    g.DrawRectangle(currentPen, rc);
            }
        }

        // Funktion för att rita en cirkel
        private void AddCircle(Graphics g)
        {
            // Skapar en ny rektangel som utgår från currentPos och startPos
            var rc = GetRectangle();

            // Om rektangeln har höjd och bredd
            if (rc.Width > 0 & rc.Height > 0)
            {
                // Om fillShape är sant ritas en ifylld ellips, 
                // annars ritas utkanten av en ellips
                if (fillShape)
                    g.FillEllipse(new SolidBrush(currentPen.Color), rc);
                else
                    g.DrawEllipse(currentPen, rc);
            }
        }

        // Aktiveras när panelen ska uppdateras/ritas om
        protected override void OnPaint(PaintEventArgs e)
        {
            // Ritar ut bitmapen på panelen
            e.Graphics.DrawImageUnscaled(bitmap, new Point(0, 0));

            // Om en form ritas och frihandsverktyget inte är aktiverat
            if (drawing == true && freehandActive == false)
            {
                // Beroende på vilken typ currentShape är ritas en temporär röd linje på panelen,
                // som utgår från startPos och currentPos
                if (currentShape is RectangleShape)
                    e.Graphics.DrawRectangle(Pens.Red, GetRectangle());
                else if (currentShape is CircleShape)
                    e.Graphics.DrawEllipse(Pens.Red, GetRectangle());
                else if (currentShape is LineShape)
                    e.Graphics.DrawLine(Pens.Red, startPos, currentPos);
            }
        }

        // Funktion för att spara bitmapen som en bild-fil (används inte)
        public void SaveDrawing()
        {
            bitmap.Save("c:\\myBitmap.bmp"); // Sparar bitmapen som en .bmp i C:\ på datorn
        }

        // Funktion för att ångra en ändring
        public void UndoChange()
        {
            // Om det finns fler än en bitmap i historiken
            if(bitmapHistory.Count > 1)
            {
                // Lägger till den senaste bitmapen i listan för ångrade bitmaps
                undoHistory.Add(bitmapHistory[bitmapHistory.Count - 1]);
                // Tar bort den sista bitmapen i historiken
                bitmapHistory.RemoveAt(bitmapHistory.Count - 1);
                // Ändrar bitmap till en kopia av den bitmap som nu är sist i historiken
                bitmap = new Bitmap(bitmapHistory[bitmapHistory.Count - 1]);
                this.Invalidate(); // Ritar om panelen
            }
        }

        // Funktion för att gå tillbaka efter en ångrad ändring
        public void RedoChange()
        {
            // Om det finns en bitmap i listan för ångrade bitmaps
            if(undoHistory.Count > 0)
            {
                // Lägger till den sista bitmapen i listan för ångrade bitmaps i historiken för aktiva bitmaps
                bitmapHistory.Add(undoHistory[undoHistory.Count - 1]);
                // Tar bort den sista bitmapen i listan för ångrade bitmaps
                undoHistory.RemoveAt(undoHistory.Count - 1);
                // Ändrar bitmap till en kopia av den bitmap som nu är sist i historiken
                bitmap = new Bitmap(bitmapHistory[bitmapHistory.Count - 1]);
                this.Invalidate(); // Ritar om panelen
            }
        }
    }
}
