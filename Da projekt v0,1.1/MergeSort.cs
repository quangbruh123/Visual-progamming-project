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
    class MergeSort : SortEngine
    {
        List<Item> items;
        List<Todo> todos;
        SortSimulation sm;
        int sortOder = 1;

        public MergeSort(SortSimulation sortsim)
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
            MSort(items, 0, items.Count - 1);
            sw.Stop();
            return ((int)sw.ElapsedMilliseconds);//trả về thời gian sort.
        }
        public void MSort(List<Item> items, int leftModule, int rightModule)
        {
            if (leftModule > rightModule)
                return;
            int mid = (leftModule + rightModule) / 2;

            FillColor(leftModule, mid);
            MSort(items, leftModule, mid);

            FillColor(mid + 1, rightModule);
            MSort(items, mid + 1, rightModule);

            FillColor(leftModule, rightModule);
            Merge(items, leftModule, mid, rightModule);

            todos.Add(new Todo("Refresh"));
        }
        public void Merge(List<Item> items, int leftModule, int mid, int rightModule)
        {
            int[] temp = new int[rightModule - leftModule + 1];
            int povet = 0;
            int i = leftModule;
            int j = mid + 1;
            while (!(i > mid && j > rightModule))
            {
                if ((i <= mid && j <= rightModule && items[i].data * sortOder < items[j].data * sortOder) || j > rightModule)
                    temp[povet++] = items[i++].data;
                else
                    temp[povet++] = items[j++].data;
            }
            for (i = 0; i < temp.Length; i++)
                items[leftModule + i].data = temp[i];
            for (j = leftModule; j <= rightModule; j++)
                todos.Add(new Todo("ResetColor", j));
            todos.Add(new Todo("Refresh"));
        }
        public void FillColor(int left, int right)
        {
            Random rand = new Random();
            Byte[] b = new byte[1];
            rand.NextBytes(b);
            Color colorPick = Color.FromArgb(255, b[0], b[0], b[0]);
            for (int i = left; i <= right; i++)
            {
                todos.Add(new Todo("ChangeColor", i, colorPick));
            }
            todos.Add(new Todo("Refresh"));
        }
    }
}
