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

        public InsertionSort(SortSimulation sortsim, List<Item> refitem, ref List<Todo> reftodo)
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
            todos.Add(new Todo("IntroInsert"));
            for (int i = 1; i < items.Count; i++)
            {
                //todos.Add(new Todo("FancyPause"));
                int key = items[i].data;
                int j;
                int reset = 0;
                todos.Add(new Todo("ChangeColor", i, Colors.Red));
                todos.Add(new Todo("Starting", i)); // starting index i
                //todos.Add(new Todo("FancyPause"));
                todos.Add(new Todo("Refresh"));
                //todos.Add(new Todo("ChangeColor", i, Colors.Green));
                for (j = i - 1; j >= 0 && key * sortOder < items[j].data * sortOder; j--)
                {
                    todos.Add(new Todo("ChangeColor", j + 1, Colors.Green));
                    items[j + 1].data = items[j].data;
                    todos.Add(new Todo("SwitchIS", j, j + 1)); // chỗ này switch nhưng không thông báo gì cả 
                    //todos.Add(new Todo("ChangeColor", j, Colors.Green));
                    reset = j;
                }

                if (reset != 0)
                    todos.Add(new Todo("ChangeColor", reset, Colors.Red));
                else if (j < 0)
                {
                    todos.Add(new Todo("ChangeColor", 0, Colors.Red));
                    reset = j + 1;
                }    
                    
                todos.Add(new Todo("AnnouceInsert", i, reset)); // thông báo đã chèn phần tử thứ i về đúng chỗ
                todos.Add(new Todo("Refresh"));
                //todos.Add(new Todo("FancyPause"));
                items[j + 1].data = key;
                //todos.Add(new Todo("Refresh"));
                todos.Add(new Todo("ResetColor", i));
                for (j = reset; j < i; j++)
                {
                    todos.Add(new Todo("ResetColor", j));
                }
                todos.Add(new Todo("Done", i));
            }
            
            todos.Add(new Todo("Refresh"));
            sw.Stop();
            return ((int)sw.ElapsedMilliseconds);//trả về thời gian sort.
        }
        public void SortAsThread()
        { }
    }
}
