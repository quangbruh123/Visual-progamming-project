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
    public class Item
    {
        public int data;

        public Pen pen = new Pen(Color.Yellow, 5f);
        public Point location = new Point();
        public Color backgroundColor = Color.Yellow;
        public Color textColor = Color.Black;

        public Item(int i)
        {
            data = i;
        }

        public Item(int i, Point defLocation)
        {
            data = i;
            location = defLocation;
        }
    }
}
