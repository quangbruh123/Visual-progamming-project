using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Sorting_Algorithms_Simulator
{
    class Visualizer
    {
        Graphics grph;

        public Visualizer(Graphics g)
        {
            grph = g;
        }

        public void Test()
        {
            Pen pen = new Pen(Color.Black, 5f);
            Rectangle rect = new Rectangle(10, 10, 200, 200);
            grph.DrawRectangle(pen, rect);
        }

        public void DrawItem(Item i)
        {
            Rectangle rect = new Rectangle(i.location.X, i.location.Y, 20, 20);

            System.Drawing.SolidBrush br = new System.Drawing.SolidBrush(i.backgroundColor);
            grph.FillRectangle(br,rect);
            br = new System.Drawing.SolidBrush(i.textColor);
            grph.DrawString(i.data.ToString(), SystemFonts.DefaultFont, br, i.location);
        }
    }
}
