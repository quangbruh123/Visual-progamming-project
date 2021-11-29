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
    class InterchangeSort : SortEngine
    {
        List<Item> items;
        List<Todo> todos;
        SortSimulation sm;
        int sortOder = 1;

        public InterchangeSort(SortSimulation sortsim, List<Item> refitem, ref List<Todo> reftodo)
        {
            items = refitem;
            todos = reftodo;
            sm = sortsim;
        }

        //bắt buộc phải sử dụng LearnSortPanel.instance.refresh()
        //thay vì sm.refresh() nếu sort bằng thread.
        //ko cần thiết nếu ko dùng thread
        //do được viết trước khi bỏ dùng thread
        //nên LearnSortPanel.instance.refresh() nên chưa thay.
        //xài cái nào cũng đc
        public int SortAsMethod()
        {
            Stopwatch sw = new Stopwatch();
            todos.Add(new Todo("Refresh"));
            for (int i = 0; i < items.Count; i++)
            { 
                todos.Add(new Todo("FancyPause"));
                todos.Add(new Todo("ChangeColor", i, Colors.Red));
                todos.Add(new Todo("FancyPause"));
                for (int j = i + 1; j < items.Count; j++) 
                {
                    todos.Add(new Todo("ChangeColor", j, Colors.Green));
                    todos.Add(new Todo("Refresh"));

                    if (items[i].data * sortOder > items[j].data * sortOder)
                    {
                        todos.Add(new Todo("ChangeColor", j, Colors.Blue));
                        todos.Add(new Todo("Switch", i, j));
                        int Backup = items[i].data;
                        items[i].data = items[j].data;
                        items[j].data = Backup;
                    }
                    todos.Add(new Todo("ResetColor", j));
                    todos.Add(new Todo("Refresh"));
                }
                todos.Add(new Todo("FancyPause"));
                todos.Add(new Todo("Refresh"));
                todos.Add(new Todo("ResetColor", i));
            }

            sw.Stop();
            return ((int)sw.ElapsedMilliseconds);//trả về thời gian sort.
        }
        public void SortAsThread()
        { }
    }
}
