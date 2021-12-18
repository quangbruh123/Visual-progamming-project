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

        public QuickSort(SortSimulation sortsim, List<Item> refitem, ref List<Todo> reftodo)
        {
            items = refitem;
            todos = reftodo;
            sm = sortsim;
        }

        public void SortWithDescription()
        {
            todos.Add(new Todo("IntroQS"));
            todos.Add(new Todo("Refresh"));
            QSort(ref items, 0, items.Count - 1);
        }

        public int SortWithResult(ref List<Item> returnItems)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            todos.Add(new Todo("IntroQS"));
            todos.Add(new Todo("Refresh"));
            QSort(ref returnItems, 0, items.Count - 1);

            sw.Stop();
            return ((int)sw.ElapsedMilliseconds);//trả về thời gian sort.
        }

        public int SortAsMethod()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            todos.Add(new Todo("IntroQS"));
            todos.Add(new Todo("Refresh"));
            QSort(ref items, 0, items.Count - 1);
            sw.Stop();
            return ((int)sw.ElapsedMilliseconds);//trả về thời gian sort.
        }

        public void QSort(ref List<Item> items, int low, int high)
        {
            if (low < high)
            {
                /* pi là chỉ số nơi phần tử này đã đứng đúng vị trí
                 và là phần tử chia mảng làm 2 mảng con trái & phải */
                int pi = partition(ref items, low, high);

                // Gọi đệ quy sắp xếp 2 mảng con trái và phải
                QSort(ref items, low, pi - 1);
                QSort(ref items, pi + 1, high);
            }
        }

        private int partition(ref List<Item> items, int low, int high)
        {
            int pivot = items[high].data;    // pivot
            int left = low;
            int right = high - 1;
            todos.Add(new Todo("ChangeColor", high, Colors.Blue));
            todos.Add(new Todo("ChangeColor", left, Colors.Red));
            todos.Add(new Todo("ChangeColor", right, Colors.Yellow));
            todos.Add(new Todo("DescriptQS", high, left, right));
            todos.Add(new Todo("Refresh"));
            while (true)
            {
                todos.Add(new Todo("Xét bên trái")); // xét nửa mảng trái nè
                while (true)
                {
                    if (left <= right && items[left].data < pivot)
                    {
                        todos.Add(new Todo("ResetColor", left));
                        left++;
                        if (left < high)
                        {
                            todos.Add(new Todo("ChangeColor", left, Colors.Red));
                            todos.Add(new Todo("StartingLeft", left));
                            todos.Add(new Todo("Refresh"));
                        }
                    }
                    else
                    {
                        // lúc này nó có thể sẽ xét hết nửa mảng trái hoặc cái pivot nhỏ hơn cái data
                        // add sub ở đây
                        break;
                    }
                }

                todos.Add(new Todo("Xét bên phải")); // xét nửa mảng phải nè
                while (true)
                {
                    if (right >= left && items[right].data > pivot)
                    {
                        todos.Add(new Todo("ResetColor", right));
                        right--;
                        if (right > low)
                        {
                            todos.Add(new Todo("ChangeColor", right, Colors.Yellow));
                            todos.Add(new Todo("StartingRight", right));
                            todos.Add(new Todo("Refresh"));
                        }
                        else
                        {
                            // lúc này nó có thể sẽ xét hết nửa mảng phải hoặc cái pivot lớn hơn cái data
                            // add sub ở đây
                            break;
                        }

                    }
                }
                if (left >= right) break;
                int temp = items[left].data;
                items[left].data = items[right].data;
                items[right].data = temp;
                todos.Add(new Todo("Switch", left, right));
                //todos.Add(new Todo("ResetColor", left));
                //todos.Add(new Todo("ResetColor", right));
                todos.Add(new Todo("ChangeColor", left, Colors.Orange));
                todos.Add(new Todo("ChangeColor", right, Colors.Orange));
                todos.Add(new Todo("Refresh"));

                todos.Add(new Todo("ResetColor", left));
                todos.Add(new Todo("ResetColor", right));

                left++;
                right--;

                todos.Add(new Todo("ChangeColor", left, Colors.Red));
                todos.Add(new Todo("ChangeColor", right, Colors.Yellow));
                todos.Add(new Todo("DiffQS"));
                todos.Add(new Todo("Refresh"));
            }
            int tmp = items[left].data;
            items[left].data = items[high].data;
            items[high].data = tmp;
            todos.Add(new Todo("Switch", left, high));

            if (left <= high)
            {
                todos.Add(new Todo("ChangeColor", left, Colors.Orange));
            }
            if (right >= low)
            {
                todos.Add(new Todo("ResetColor", right));
            }
            todos.Add(new Todo("ChangeColor", high, Colors.Orange));
            todos.Add(new Todo("Refresh"));
            if (left <= high)
                todos.Add(new Todo("ResetColor", left));
            todos.Add(new Todo("ResetColor", high));
            return left;
        }
    }
}
