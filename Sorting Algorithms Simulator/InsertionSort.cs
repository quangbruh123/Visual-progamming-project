using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;


namespace Sorting_Algorithms_Simulator
{
    class InsertionSort : SortEngine
    {
        SortProject form;
        Visualizer vslz;
        public InsertionSort()
        {
            form = SortProject.instance;
            vslz = form.vslz;
        }

        public void Sort()
        {
            //vslz.Reset();
            //Font f = new Font(FontFamily.GenericSansSerif, 20f, FontStyle.Regular, GraphicsUnit.Pixel);

            //int i, key, j;
            //for (i = 1; i < n; i++)
            //{
            //    key = arr[i];
            //    j = i - 1;

            //    /* Move elements of arr[0..i-1], that are
            //    greater than key, to one position ahead
            //    of their current position */
            //    while (j >= 0 && arr[j] > key)
            //    {
            //        arr[j + 1] = arr[j];
            //        j = j - 1;
            //    }
            //    arr[j + 1] = key;
            //}
        }
    }
}
