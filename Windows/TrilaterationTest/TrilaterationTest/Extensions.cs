using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace TrilaterationTest
{
    public static class Extensions
    {
        public static void DrawPoint(this Graphics gr,
            Brush brush, Pen pen, PointF point, float radius)
        {
            RectangleF rect = new RectangleF(
                point.X - radius,
                point.Y - radius,
                2 * radius,
                2 * radius);
            gr.FillEllipse(brush, rect);
            gr.DrawEllipse(pen, rect);
        }
    }
}
