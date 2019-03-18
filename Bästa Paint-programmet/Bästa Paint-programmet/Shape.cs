using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Bästa_Paint_programmet
{
    // En basklass för andra former
    abstract class Shape
    {
        public Color color;         // Färgen på figuren
        public float borderWidth;   // Bredden på figurens utkant

        // Figurens start- och slutposition, bara relevant för linjer
        public Point startPoint;    
        public Point endPoint;

        // Sparar en privat rektangel
        private Rectangle rect;
        // En allmän property för att hämta och ändra den privata rektangeln
        public Rectangle Rect {
            // När Rect hämtas returneras rektangeln som sparas i den privata variabeln
            get
            {
                return this.rect;
            }
            // När Rect ändras ändras den privata rektangeln och startPoint och endPoint
            // uppdateras så att de sparar rektangelns övre vänstra och nedre högra hörn
            set
            {
                this.rect = value;
                this.startPoint = new Point(value.X, value.Y);
                this.endPoint = new Point(value.X + value.Width, value.Y + value.Height);
            }
        }
    }
}
