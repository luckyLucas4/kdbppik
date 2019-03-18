using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Bästa_Paint_programmet
{
    // En cirkelfigur som ärver från Shape
    class CircleShape : Shape
    {
        // En konstruktor som sätter några fördefinierade värden på färgen, 
        // tjockleken på utkanten samt rektangeln, utan att parametrar behövs skickas med
        public CircleShape()
        {
            this.color = Color.Black;
            this.borderWidth = 10;
            this.Rect = new Rectangle(0, 0, 50, 50);
        }
        // En konstruktor som tar in och använder parametrar för färg, 
        // tjocklek på utkanten och en rektangel
        public CircleShape(Color color, float width, Rectangle rect)
        {
            this.color = color;
            this.borderWidth = width;
            this.Rect = rect;
        }
    }
}
