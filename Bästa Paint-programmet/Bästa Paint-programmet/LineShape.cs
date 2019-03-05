using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Bästa_Paint_programmet
{
    class LineShape : Shape
    {
        
        public LineShape()
        {
            this.color = Color.Black;
            this.borderWidth = 10;
            this.Rect = new Rectangle(0, 0, 50, 50);
            this.startPoint = new Point(Rect.X, Rect.Y);
        }
        public LineShape(Color color, float width, Point startPoint, Point endPoint)
        {
            this.color = color;
            this.borderWidth = width;
            this.startPoint = startPoint;
            this.endPoint = endPoint;
        }
    }
}
