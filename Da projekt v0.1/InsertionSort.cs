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
    class InsertionSort : SortEngine
    {
        List<Item> items;
        List<Todo> todos;
        SortSimulation sm;
        int sortOder = 1;

        public InsertionSort(SortSimulation sortsim)
        {
            items = sortsim.items;
            todos = sortsim.todos;
            sm = sortsim;
        }

        //bắt buộc phải sử dụng LearnSortPanel.instance.refresh()
        //thay vì sm.refresh() nếu sort bằng thread.
        //ko cần thiết nếu ko dùng thread
        //do được viết trước khi bỏ dùng thread
        //nên LearnSortPanel.instance.refresh() nên chưa thay.
        //xài cái nào cũng đc
        public int Sort()
        {
            Stopwatch sw = new Stopwatch();
            todos.Add(new Todo("Refresh"));

            sw.Start();
            for (int i = 0; i < items.Count; i++)
            {
                int key = items[i].data;
                int j;
                todos.Add(new Todo("ChangeColor", i, Colors.Red));
                for (j = i - 1; j >= 0 && key*sortOder < items[j].data*sortOder; j++) 
                {
                    items[j + 1].data = items[j].data;
                    todos.Add(new Todo("ChangeColor", j, Colors.Green));
                    todos.Add(new Todo("Refresh"));
                }
                items[j + 1].data = key;
                todos.Add(new Todo("ResetColor", i));
            }

            sw.Stop();
            return ((int)sw.ElapsedMilliseconds);//trả về thời gian sort.
        }
    }
}
