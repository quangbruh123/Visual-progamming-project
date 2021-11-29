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

        public QuickSort(SortSimulation sortsim, List<Item> refitem, ref List<Todo> reftodo)
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
            QSort(items, 0, items.Count - 1);
            sw.Stop();
            return ((int)sw.ElapsedMilliseconds);//trả về thời gian sort.
        }
        public void QSort(List<Item> items, int low, int high)
        {
            if (low < high)
            {
                /* pi là chỉ số nơi phần tử này đã đứng đúng vị trí
                 và là phần tử chia mảng làm 2 mảng con trái & phải */
                int pi = partition(items, low, high);

                // Gọi đệ quy sắp xếp 2 mảng con trái và phải
                QSort(items, low, pi - 1);
                QSort(items, pi + 1, high);
            }

        }
        private int partition(List<Item> items, int low, int high)
        {
            int pivot = items[high].data;    // pivot
            int left = low;
            int right = high - 1;
            todos.Add(new Todo("ChangeColor", high, Colors.Blue));
            todos.Add(new Todo("ChangeColor", left, Colors.Red));
            todos.Add(new Todo("ChangeColor", right, Colors.Yellow));
            todos.Add(new Todo("Refresh"));
            while (true)
            {
                while (left <= right && items[left].data < pivot)
                {
                    todos.Add(new Todo("ResetColor", left));
                    left++;
                    if (left <= high)
                    {
                        todos.Add(new Todo("ChangeColor", left, Colors.Red));
                    }
                    todos.Add(new Todo("Refresh"));
                }
                while (right >= left && items[right].data > pivot)
                {
                    todos.Add(new Todo("ResetColor", right));
                    right--;
                    if (right >= low)
                    {
                        todos.Add(new Todo("ChangeColor", right, Colors.Yellow));
                    }
                    todos.Add(new Todo("Refresh"));
                }
                if (left >= right) break;
                int temp = items[left].data;
                items[left].data = items[right].data;
                items[right].data = temp;
                todos.Add(new Todo("Switch", left, right));
                todos.Add(new Todo("ResetColor", left));
                todos.Add(new Todo("ResetColor", right));

                left++;
                right--;

                todos.Add(new Todo("ChangeColor", left, Colors.Red));
                todos.Add(new Todo("ChangeColor", right, Colors.Yellow));
                todos.Add(new Todo("Refresh"));
            }
            int tmp = items[left].data;
            items[left].data = items[high].data;
            items[high].data = tmp;
            todos.Add(new Todo("Switch", left, high));
            if (left <= high)
            {
                todos.Add(new Todo("ResetColor", left));
            }
            if (right >= low)
            {
                todos.Add(new Todo("ResetColor", right));
            }
            todos.Add(new Todo("ResetColor", high));
            todos.Add(new Todo("Refresh"));
            return left;
        }

        public void SortAsThread()
        { }
    }
}
//public void QSortAsMethod(List<Item> items, int leftModule, int rightModule)
//{
//    //todos.Add(new Todo("FancyPause"));
//    int i, j, pivot, mid;
//    mid = (leftModule + rightModule) / 2;
//    pivot = items[mid].data;
//    i = leftModule;
//    j = rightModule;
//    todos.Add(new Todo("ChangeColor", i, Colors.Red));
//    todos.Add(new Todo("ChangeColor", j, Colors.Green));
//    todos.Add(new Todo("ChangeColor", mid, Colors.Blue));
//    todos.Add(new Todo("Refresh"));
//    //todos.Add(new Todo("FancyPause"));
//    while (i <= j)
//    {
//        todos.Add(new Todo("Refresh"));
//        //todos.Add(new Todo("FancyPause"));
//        while ((items[i].data < pivot) && (i <= j))
//        {
//            todos.Add(new Todo("ResetColor", i));
//            i++;
//            todos.Add(new Todo("ChangeColor", i, Colors.Red));
//            todos.Add(new Todo("Refresh"));
//        }

//        //todos.Add(new Todo("FancyPause"));
//        while ((items[j].data > pivot) && (j >= i))
//        {
//            todos.Add(new Todo("ResetColor", j));
//            j--;
//            todos.Add(new Todo("ChangeColor", j, Colors.Green));
//            todos.Add(new Todo("Refresh"));
//        }

//        //todos.Add(new Todo("FancyPause"));
//        if (i <= j)
//        {
//            if (i < j)
//            {
//                todos.Add(new Todo("ResetColor", i));
//                todos.Add(new Todo("ResetColor", j));
//                todos.Add(new Todo("Switch", i, j));
//                todos.Add(new Todo("Refresh"));
//                int Backup = items[i].data;
//                items[i].data = items[j].data;
//                items[j].data = Backup;
//            }
//            i++;
//            j--;
//            //todos.Add(new Todo("FancyPause"));
//            if (i <= rightModule)
//            {
//                todos.Add(new Todo("ChangeColor", i, Colors.Green));
//            }
//            if (j >= leftModule)
//            {
//                todos.Add(new Todo("ChangeColor", j, Colors.Red));
//            }
//        }
//        todos.Add(new Todo("Refresh"));
//    }
//    if (i <= rightModule)
//    {
//        todos.Add(new Todo("ResetColor", i));
//    }
//    if (j >= leftModule)
//    {
//        todos.Add(new Todo("ResetColor", j));
//    }
//    todos.Add(new Todo("Refresh"));
//    if (leftModule < j)
//    {
//        QSortAsMethod(items, leftModule, j);
//    }
//    if (i < rightModule)
//    {
//        QSortAsMethod(items, i, rightModule);
//    }

//}