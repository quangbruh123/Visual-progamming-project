using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Da_projekt
{
    class MS : SortEngine
    {
        List<Item> items;
        List<Todo> todos;
        SortSimulation sm;

        public MS(SortSimulation sortsim, List<Item> refitem, ref List<Todo> reftodo)
        {
            items = refitem;
            todos = reftodo;
            sm = sortsim;
        }

        public int SortAsMethod()
        {
            Stopwatch sw = new Stopwatch();
            todos.Add(new Todo("Refresh"));
            sort(items, 0, items.Count - 1);
            sw.Stop();
            return ((int)sw.ElapsedMilliseconds);
        }

        void merge(List<Item> items, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;


            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;


            for (i = 0; i < n1; ++i)
                L[i] = items[l + i].data;
            for (j = 0; j < n2; ++j)
                R[j] = items[m + 1 + j].data;


            i = 0;
            j = 0;


            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    items[k].data = L[i];
                    i++;
                }
                else
                {
                    items[k].data = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                items[k].data = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                items[k].data = R[j];
                j++;
                k++;
            }
        }

        void sort(List<Item> items, int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;
                sort(items, l, m);
                sort(items, m + 1, r);
                todos.Add(new Todo("ChangeColor", l, Colors.Green));
                todos.Add(new Todo("ChangeColor", r, Colors.Green));
                todos.Add(new Todo("ChangeColor", m, Colors.Blue));
                todos.Add(new Todo("Refresh"));

                merge(items, l, m, r);
                todos.Add(new Todo("DrawSameTime", l, m, r));
            }
        }

        public void SortAsThread() { }

        public void SortWithDescription() { }

        public int SortWithResult(ref List<Item> items)
        {
            return 2;
        }
    }
}
