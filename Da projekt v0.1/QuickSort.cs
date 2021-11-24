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
    class QuickSort : SortEngine
    {
        List<Item> items;
        List<Todo> todos;
        SortSimulation sm;
        int sortOder = 1;

        public QuickSort(SortSimulation sortsim)
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
            QSort(items, 0, items.Count - 1);
            sw.Stop();
            return ((int)sw.ElapsedMilliseconds);//trả về thời gian sort.
        }
        public void QSort(List<Item> items, int leftModule, int rightModule)
        {
            int i, j, povet, mid;
            mid = (leftModule + rightModule) / 2;
            povet = items[mid].data;
            i = leftModule;
            j = rightModule;
            todos.Add(new Todo("ChangeColor", i, Colors.Green));
            todos.Add(new Todo("ChangeColor", j, Colors.Red));
            todos.Add(new Todo("ChangeColor", mid, Colors.Blue));
            todos.Add(new Todo("Refresh"));
            while (i <= j)
            {
                todos.Add(new Todo("Refresh"));
                while ((items[i].data*sortOder<povet*sortOder)&&(i<=j))
                {
                    todos.Add(new Todo("ResetColor", i));
                    i++;
                    todos.Add(new Todo("ChangeColor", i, Colors.Green));
                    todos.Add(new Todo("Refresh"));
                }
                while ((items[j].data*sortOder>povet*sortOder)&&(j>=i))
                {
                    todos.Add(new Todo("ResetColor", j));
                    j++;
                    todos.Add(new Todo("ChangeColor", j, Colors.Red));
                    todos.Add(new Todo("Refresh"));
                }
                if (i<=j)
                {
                    if (i<j)
                    {
                        todos.Add(new Todo("ResetColor", i));
                        todos.Add(new Todo("ResetColor", j));
                        todos.Add(new Todo("Switch", i, j));
                        int Backup = items[i].data;
                        items[i].data = items[j].data;
                        items[j].data = Backup;
                    }
                    i++;
                    j--;
                    if (i<=rightModule)
                    {
                        todos.Add(new Todo("ChangeColor", i, Colors.Green));
                    }
                    if (j>=leftModule)
                    {
                        todos.Add(new Todo("ChangeColor", i, Colors.Red));
                    }
                }
                todos.Add(new Todo("Refresh"));
            }
            if (leftModule<j)
            {
                QSort(items, leftModule, j);
            }
            if (i<rightModule)
            {
                QSort(items, i, rightModule);
            }

        }
    }
}
