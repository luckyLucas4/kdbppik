using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Bästa_Paint_programmet
{
    class RectangleShape : Shape
    {
        public RectangleShape()
        {
            this.color = Color.Black;
            this.borderWidth = 10;
            this.Rect = new Rectangle(0, 0, 50, 50);
        }
        public RectangleShape(Color color, float width, Rectangle rect)
        {
            this.color = color;
            this.borderWidth = width;
            this.Rect = rect;
            this.startPoint = new Point(rect.X, rect.Y);
            this.endPoint = new Point(rect.X + rect.Width, rect.Y + rect.Height);
        }
    }
}
