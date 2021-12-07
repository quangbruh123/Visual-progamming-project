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
        TextBox textBox;
        public InterchangeSort(SortSimulation sortsim, List<Item> refitem, ref List<Todo> reftodo, TextBox t)
        {
            items = refitem;
            todos = reftodo;
            sm = sortsim;
            textBox = t;
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
            todos.Add(new Todo("IntroInterchange", textBox));
            todos.Add(new Todo("Refresh"));
            for (int i = 0; i < items.Count - 1; i++)
            { 
                //todos.Add(new Todo("FancyPause"));
                todos.Add(new Todo("ChangeColor", i, Colors.Red)); // starting index i
                todos.Add(new Todo("Starting", i, textBox));
                todos.Add(new Todo("Refresh"));
                //todos.Add(new Todo("FancyPause"));
                for (int j = i + 1; j < items.Count; j++) 
                {
                    todos.Add(new Todo("ChangeColor", j, Colors.Orchid)); // starting index j
                    todos.Add(new Todo("StartingSub", j, textBox));
                    todos.Add(new Todo("Refresh"));

                    if (items[i].data * sortOder > items[j].data * sortOder)
                    {
                        todos.Add(new Todo("ChangeColor", i, Colors.Green));
                        todos.Add(new Todo("ChangeColor", j, Colors.Green));                       
                        todos.Add(new Todo("Switch", i, j, textBox)); // swap i j
                        todos.Add(new Todo("Refresh"));
                        todos.Add(new Todo("ChangeColor", i, Colors.Red));
                        int Backup = items[i].data;
                        items[i].data = items[j].data;
                        items[j].data = Backup;
                    }
                    todos.Add(new Todo("ResetColor", j));
                    //todos.Add(new Todo("Refresh"));
                }
                //todos.Add(new Todo("FancyPause"));
                todos.Add(new Todo("ResetColor", i));
                todos.Add(new Todo("DoneIC", i, textBox)); // xong vòng lặp của thứ i
                todos.Add(new Todo("Refresh"));
            }
            todos.Add(new Todo("Done", textBox));
            todos.Add(new Todo("Refresh"));
            sw.Stop();
            return ((int)sw.ElapsedMilliseconds);//trả về thời gian sort.
        }
        public void SortAsThread()
        { }
    }
}
