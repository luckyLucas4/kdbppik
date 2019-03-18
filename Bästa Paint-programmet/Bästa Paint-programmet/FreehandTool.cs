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
    // Objektet sparar några värden som behövs för att rita på frihand
    class FreehandTool
    {
        public Point position;  // Förra positionen där verktyget användes
        public bool draw;       // Indikerar om något ritas med verktyget

        // En konstruktor som sätter position till en första punkt utanför panelen och draw till false
        public FreehandTool()
        {
            position = new Point(-1, -1);
            draw = false;
        }
    }
}
