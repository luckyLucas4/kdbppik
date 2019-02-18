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
    class DrawingPen
    {
        Point position;
        bool draw;

        public DrawingPen()
        {
            position = new Point(-1, -1);
            draw = false;
        }
    }
}
