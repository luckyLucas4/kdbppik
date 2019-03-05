using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Bästa_Paint_programmet
{
    abstract class Shape
    {
        public Color color;
        public float borderWidth;
        public Point startPoint;
        public Point endPoint;
        private Rectangle rect;
        public Rectangle Rect {
            get
            {
                return this.rect;
            }
            set
            {
                this.rect = value;
                this.startPoint = new Point(value.X, value.Y);
                this.endPoint = new Point(value.X + value.Width, value.Y + value.Height);
            }
        }
    }
}
