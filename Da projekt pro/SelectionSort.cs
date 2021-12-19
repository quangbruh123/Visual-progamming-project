using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Diagnostics;

namespace Da_projekt
{
    class SelectionSort : SortEngine
    {
        List<Item> items;
        List<Todo> todos;
        SortSimulation sm;

        public SelectionSort(SortSimulation sortsim, List<Item> refitem, ref List<Todo> reftodo)
        {
            items = refitem;
            todos = reftodo;
            sm = sortsim;
        }

        //bắt buộc phải sử dụng LearnSortPanel.instance.refresh() thay vì sm.refresh() nếu sort bằng thread. ko cần thiết nếu ko dùng thread
        //do được viết trước khi bỏ dùng thread nên LearnSortPanel.instance.refresh() nên chưa thay. xài cái nào cũng đc

        public void SortWithDescription()
        {
            todos.Add(new Todo("Refresh"));
            todos.Add(new Todo("IntroSS")); // intro giải thích sơ bộ về selection sort
            for (int i = 0; i < items.Count - 1; i++)
            {
                int min = i;
                //todos.Add(new Todo("FancyPause"));
                todos.Add(new Todo("ChangeColor", i, Colors.Red));
                todos.Add(new Todo("Starting", i)); // starting index i;
                todos.Add(new Todo("Refresh"));
                for (int j = i + 1; j < items.Count; j++)
                {
                    todos.Add(new Todo("ChangeColor", j, Colors.Orchid));
                    todos.Add(new Todo("StartingSub", j)); // đang đi tìm phần tử nhỏ hơn min
                    todos.Add(new Todo("Refresh"));

                    if (items[min].data > items[j].data)
                    {
                        if (min != i)
                            todos.Add(new Todo("ResetColor", min));
                        min = j;
                        todos.Add(new Todo("ChangeColor", min, Colors.Blue));
                        todos.Add(new Todo("ConfirmMin", min));
                        todos.Add(new Todo("Refresh"));
                    }
                    else
                    {
                        todos.Add(new Todo("ResetColor", j));
                    }
                }
                if (i != min)
                {
                    todos.Add(new Todo("ChangeColor", min, Colors.Green));
                    todos.Add(new Todo("ChangeColor", i, Colors.Green));
                    //todos.Add(new Todo("FancyPause"));
                    todos.Add(new Todo("Switch", i, min)); // thông báo đã swap
                    int Backup = items[i].data;
                    items[i].data = items[min].data;
                    items[min].data = Backup;
                    todos.Add(new Todo("Refresh"));
                }
                todos.Add(new Todo("ResetColor", i));
                todos.Add(new Todo("ResetColor", min));
            }
        }

        public int SortAsMethod()
        {
            Stopwatch sw = new Stopwatch();
            todos.Add(new Todo("Refresh"));
            for (int i = 0; i < items.Count; i++)
            {
                int min = i;
                todos.Add(new Todo("FancyPause"));
                todos.Add(new Todo("ChangeColor", i, Colors.Red));
                todos.Add(new Todo("FancyPause"));

                for (int j = i + 1; j < items.Count; j++)
                {
                    todos.Add(new Todo("ChangeColor", j, Colors.Green));
                    todos.Add(new Todo("Refresh"));

                    if (items[min].data > items[j].data)
                    {
                        if (min != i)
                            todos.Add(new Todo("ResetColor", min));

                        min = j;
                        todos.Add(new Todo("ChangeColor", min, Colors.Blue));
                    } else
                    {
                        todos.Add(new Todo("ResetColor", j));
                    }
                }
                if (i != min)
                {
                    todos.Add(new Todo("ResetColor", min));
                    todos.Add(new Todo("Refresh"));

                    todos.Add(new Todo("FancyPause"));

                    todos.Add(new Todo("Refresh"));
                    todos.Add(new Todo("Switch", i, min));
                    int Backup = items[i].data;
                    items[i].data = items[min].data;
                    items[min].data = Backup;
                }
                todos.Add(new Todo("ResetColor", i));
            }
            sw.Stop();
            return ((int)sw.ElapsedMilliseconds);//trả về thời gian sort.
        }

        public int SortWithResult(ref List<Item> returnItems)
        {
            returnItems = sm.CreateCopy(items);

            Stopwatch sw = new Stopwatch();
            sw.Start();

            todos.Add(new Todo("Refresh"));
            for (int i = 0; i < returnItems.Count; i++)
            {
                int min = i;
                todos.Add(new Todo("ChangeColor", i, Colors.Red));

                for (int j = i + 1; j < returnItems.Count; j++)
                {
                    todos.Add(new Todo("ChangeColor", j, Colors.Green));
                    todos.Add(new Todo("Refresh"));

                    if (returnItems[min].data > returnItems[j].data)
                    {
                        if (min != i)
                            todos.Add(new Todo("ResetColor", min));

                        min = j;
                        todos.Add(new Todo("ChangeColor", min, Colors.Blue));
                    }
                    else
                    {
                        todos.Add(new Todo("ResetColor", j));
                    }
                }
                if (i != min)
                {
                    todos.Add(new Todo("ResetColor", min));
                    todos.Add(new Todo("Refresh"));

                    todos.Add(new Todo("Refresh"));
                    todos.Add(new Todo("Switch", i, min));
                    int Backup = returnItems[i].data;
                    returnItems[i].data = returnItems[min].data;
                    returnItems[min].data = Backup;
                }
                todos.Add(new Todo("ResetColor", i));
            }
            sw.Stop();
            return ((int)sw.ElapsedMilliseconds);//trả về thời gian sort.
        }
    }
}
