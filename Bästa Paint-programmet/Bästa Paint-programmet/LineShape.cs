using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Bästa_Paint_programmet
{
    // En linjefigur som ärver från Shape
    class LineShape : Shape
    {
        // En konstruktor som sätter några fördefinierade värden på färgen, 
        // tjockleken på utkanten samt rektangeln, utan att parametrar behövs skickas med
        public LineShape()
        {
            this.color = Color.Black;
            this.borderWidth = 10;
            this.Rect = new Rectangle(0, 0, 50, 50);
        }
        // En konstruktor som tar in och använder parametrar för färg, tjocklek på utkanten,
        // startpunkt och slutpunkt
        public LineShape(Color color, float width, Point startPoint, Point endPoint)
        {
            this.color = color;
            this.borderWidth = width;
            this.startPoint = startPoint;
            this.endPoint = endPoint;
        }
    }
}
