using System;
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
using System.Diagnostics;

namespace Da_projekt
{
    class SelectionSort : SortEngine
    {
        List<Item> items;
        List<Todo> todos;
        SortSimulation sm;
        int sortOder = 1;

        public SelectionSort(SortSimulation sortsim)
        {
            items = sortsim.items;
            todos = sortsim.todos;
            sm = sortsim;
        }

        //bắt buộc phải sử dụng LearnSortPanel.instance.refresh() thay vì sm.refresh() nếu sort bằng thread. ko cần thiết nếu ko dùng thread
        //do được viết trước khi bỏ dùng thread nên LearnSortPanel.instance.refresh() nên chưa thay. xài cái nào cũng đc
        public int Sort()
        {
            Stopwatch sw = new Stopwatch();
            todos.Add(new Todo("Refresh"));

            sw.Start();
            for (int i = 0; i < items.Count; i++)
            {
                int min = i;

                todos.Add(new Todo("ChangeColor", i, Colors.Red));
                for (int j = i + 1; j < items.Count; j++)
                {
                    todos.Add(new Todo("ChangeColor", j, Colors.Green));
                    todos.Add(new Todo("Refresh"));

                    if (items[min].data * sortOder > items[j].data * sortOder)
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
    }
}
