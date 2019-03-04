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
        public RectangleShape(Pen pen, Rectangle rect)
        {
            this.pen = pen;
            this.rect = rect;
        }
    }
}
