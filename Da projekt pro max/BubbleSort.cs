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
    class BubbleSort : SortEngine
    {
        List<Item> items;
        List<Todo> todos;
        SortSimulation sm;
        public BubbleSort(SortSimulation sortsim, List<Item> refitem, ref List<Todo> reftodo)
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

            for (int i = 0; i < items.Count - 1; i++)
            {
                todos.Add(new Todo("ChangeColor", i, Colors.Blue));
                for (int j = 0; j < items.Count - i - 1; j++)
                {
                    todos.Add(new Todo("ChangeColor", j, Colors.Red));
                    todos.Add(new Todo("ChangeColor", j + 1, Colors.Red));
                    if (items[j].data > items[j + 1].data)
                    {
                        // swap temp and arr[i]
                        int temp = items[j].data;
                        items[j].data = items[j + 1].data;
                        items[j + 1].data = temp;
                        todos.Add(new Todo("Switch", j, j + 1)); // swap cái cặp đó
                        todos.Add(new Todo("Refresh"));
                        //todos.Add(new Todo("ChangeColor", j, Colors.Green));
                        //todos.Add(new Todo("ChangeColor", j + 1, Colors.Green));
                    }
                    if (j == i)
                    {
                        todos.Add(new Todo("ChangeColor", j, Colors.Blue));
                    }
                    else
                    {
                        todos.Add(new Todo("ResetColor", j));
                    }

                    if (j + 1 == i)
                    {
                        todos.Add(new Todo("ChangeColor", j + 1, Colors.Blue));
                    }
                    else
                    {
                        todos.Add(new Todo("ResetColor", j + 1));
                    }
                }
                todos.Add(new Todo("ResetColor", i));
                todos.Add(new Todo("Refresh"));
            }

            sw.Stop();
            return ((int)sw.ElapsedMilliseconds);//trả về thời gian sort.
        }

        public void SortWithDescription()
        {
            todos.Add(new Todo("IntroBB")); // intro giới thiệu về BB
            todos.Add(new Todo("Refresh"));
            for (int i = 0; i < items.Count - 1; i++)
            {
                todos.Add(new Todo("ChangeColor", i, Colors.Blue));
                todos.Add(new Todo("Starting", i)); // starting index i
                todos.Add(new Todo("Refresh"));
                for (int j = 0; j < items.Count - i - 1; j++)
                {
                    todos.Add(new Todo("ChangeColor", j, Colors.Red));
                    todos.Add(new Todo("ChangeColor", j + 1, Colors.Red));
                    todos.Add(new Todo("CompareBB", j, j + 1)); // thông báo so sánh từng cặp
                    todos.Add(new Todo("Refresh"));
                    if (items[j].data > items[j + 1].data)
                    {
                        // swap temp and arr[i]
                        int temp = items[j].data;
                        items[j].data = items[j + 1].data;
                        items[j + 1].data = temp;
                        todos.Add(new Todo("Switch", j, j + 1)); // swap cái cặp đó
                        todos.Add(new Todo("SwitchDes", j, j + 1)); // thêm description
                        todos.Add(new Todo("ChangeColor", j, Colors.Green));
                        todos.Add(new Todo("ChangeColor", j + 1, Colors.Green));
                        todos.Add(new Todo("Refresh"));
                    }
                    if (j == i)
                    {
                        todos.Add(new Todo("ChangeColor", j, Colors.Blue));
                    }
                    else
                    {
                        todos.Add(new Todo("ResetColor", j));
                    }

                    if (j + 1 == i)
                    {
                        todos.Add(new Todo("ChangeColor", j + 1, Colors.Blue));
                    }
                    else
                    {
                        todos.Add(new Todo("ResetColor", j + 1));
                    }
                    todos.Add(new Todo("Refresh"));
                }
                todos.Add(new Todo("ResetColor", i));
                todos.Add(new Todo("DoneBB"));
                todos.Add(new Todo("Refresh"));
            }
        }

        public int SortWithResult(ref List<Item> returnItems)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            todos.Add(new Todo("Refresh"));

            todos.Add(new Todo("Refresh"));
            for (int i = 0; i < returnItems.Count - 1; i++)
            {
                todos.Add(new Todo("ChangeColor", i, Colors.Blue));
                todos.Add(new Todo("Refresh"));
                for (int j = 0; j < returnItems.Count - i - 1; j++)
                {
                    todos.Add(new Todo("ChangeColor", j, Colors.Red));
                    todos.Add(new Todo("ChangeColor", j + 1, Colors.Red));
                    todos.Add(new Todo("Refresh"));
                    if (returnItems[j].data > returnItems[j + 1].data)
                    {
                        // swap temp and arr[i]
                        int temp = returnItems[j].data;
                        returnItems[j].data = returnItems[j + 1].data;
                        returnItems[j + 1].data = temp;
                        todos.Add(new Todo("Switch", j, j + 1)); // swap cái cặp đó
                        todos.Add(new Todo("ChangeColor", j, Colors.Green));
                        todos.Add(new Todo("ChangeColor", j + 1, Colors.Green));
                        todos.Add(new Todo("Refresh"));
                    }
                    if (j == i)
                    {
                        todos.Add(new Todo("ChangeColor", j, Colors.Blue));
                    }
                    else
                    {
                        todos.Add(new Todo("ResetColor", j));
                    }

                    if (j + 1 == i)
                    {
                        todos.Add(new Todo("ChangeColor", j + 1, Colors.Blue));
                    }
                    else
                    {
                        todos.Add(new Todo("ResetColor", j + 1));
                    }
                    todos.Add(new Todo("Refresh"));
                }
                todos.Add(new Todo("ResetColor", i));
                todos.Add(new Todo("Refresh"));
            }

            sw.Stop();
            return ((int)sw.ElapsedMilliseconds);//trả về thời gian sort.
        }
    }
}
