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
    class HeapSort : SortEngine
    {
        List<Item> items;
        List<Todo> todos;
        SortSimulation sm;
        int sortOder = 1;

        public HeapSort(SortSimulation sortsim)
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

        //Chưa visualize, chỉ base sort

        public int Sort()
        {
            Stopwatch sw = new Stopwatch();
            todos.Add(new Todo("Refresh"));

            sw.Start();
            int n = items.Count;

            // Build heap (rearrange array) 
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(items, n, i);

            // One by one extract an element from heap 
            for (int i = n - 1; i > 0; i--)
            {
                // Move current root to end 
                int temp = items[0].data;
                items[0].data = items[i].data;
                items[i].data = temp;

                // call max Heapify on the reduced heap 
                Heapify(items, i, 0);
            }

                sw.Stop();
            return ((int)sw.ElapsedMilliseconds);//trả về thời gian sort.
        }
        // To Heapify a subtree rooted with node i which is 
        // an index in items[]. n is size of heap 
        public void Heapify(List<Item> items, int n, int i)
        {
            int largest = i; // Initialize largest as root 
            int l = 2 * i + 1; // left = 2*i + 1 
            int r = 2 * i + 2; // right = 2*i + 2 

            // If left child is larger than root 
            if (l < n && items[l].data * sortOder > items[largest].data * sortOder)
                largest = l;

            // If right child is larger than largest so far 
            if (r < n && items[r].data * sortOder > items[largest].data * sortOder)
                largest = r;

            // If largest is not root 
            if (largest != i)
            {
                int swap = items[i].data;
                items[i].data = items[largest].data;
                items[largest].data = swap;

                // Recursively Heapify the affected sub-tree 
                Heapify(items, n, largest);
            }
        }
    }
}
