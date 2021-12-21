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
            sw.Start();
            todos.Add(new Todo("Refresh"));
            sort(items, 0, items.Count - 1);
            sw.Stop();
            return ((int)sw.ElapsedMilliseconds);
        }

        public int SortWithResult(ref List<Item> refitems)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            todos.Add(new Todo("Refresh"));
            sort(refitems, 0, refitems.Count - 1);
            sw.Stop();
            items = new List<Item>(refitems);
            return ((int)sw.ElapsedMilliseconds);
        }

        public void SortWithDescription()
        {
            todos.Add(new Todo("IntroMerge"));
            todos.Add(new Todo("Refresh"));
            sort(items, 0, items.Count - 1);
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

            for (i = 0; i < m - l + 1; i++)
            {
                todos.Add(new Todo("ChangeColor", i + l, Colors.Red));
                if (i + m + 1 <= r)
                    todos.Add(new Todo("ChangeColor", i + m + 1, Colors.Red));
                todos.Add(new Todo("Refresh"));

                if (i + l == l)
                    todos.Add(new Todo("ChangeColor", i + l, Colors.Green));
                else if (i + l == m)
                    todos.Add(new Todo("ChangeColor", i + l, Colors.Blue));
                else
                    todos.Add(new Todo("ResetColor", i + l));

                if (i + m + 1 == r)
                    todos.Add(new Todo("ChangeColor", i + m + 1, Colors.Pink));
                else if (i + m + 1 < r)
                    todos.Add(new Todo("ResetColor", i + m + 1));

                todos.Add(new Todo("Refresh"));
            }

            i = 0;
            j = 0;


            int k = l;
            while (i < n1 && j < n2)
            {
                todos.Add(new Todo("ChangeColor", k, Colors.Red));
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
                int tmp = items[k].data;
                todos.Add(new Todo("UpdateNewVal", k, tmp));
                todos.Add(new Todo("Refresh"));
                if (k == l)
                    todos.Add(new Todo("ChangeColor", k, Colors.Green));
                else
                    todos.Add(new Todo("ResetColor", k));

                todos.Add(new Todo("Refresh"));
                k++;
            }

            while (i < n1)
            {
                todos.Add(new Todo("ChangeColor", k, Colors.Red));
                items[k].data = L[i];
                i++;

                int tmp = items[k].data;
                todos.Add(new Todo("UpdateNewVal", k, tmp));
                todos.Add(new Todo("Refresh"));
                if (k == r)
                    todos.Add(new Todo("ChangeColor", k, Colors.Pink));
                else
                    todos.Add(new Todo("ResetColor", k));

                todos.Add(new Todo("Refresh"));
                k++;
            }

            while (j < n2)
            {
                todos.Add(new Todo("ChangeColor", k, Colors.Red));

                items[k].data = R[j];
                j++;

                int tmp = items[k].data;
                todos.Add(new Todo("UpdateNewVal", k, tmp));
                todos.Add(new Todo("Refresh"));
                if (k == r)
                    todos.Add(new Todo("ChangeColor", k, Colors.Pink));
                else
                    todos.Add(new Todo("ResetColor", k));

                todos.Add(new Todo("Refresh"));

                k++;
            }

            todos.Add(new Todo("ResetColor", l));
            todos.Add(new Todo("ResetColor", r));
            todos.Add(new Todo("Refresh"));
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
    }
}
