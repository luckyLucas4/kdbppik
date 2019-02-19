using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Bästa_Paint_programmet
{
    class CircleShape : Shape
    {
        public CircleShape(Pen color, Rectangle rect)
        {
            this.pen = color;
            this.rect = rect;
        }
    }
}
