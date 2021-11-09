using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Sorting_Algorithms_Simulator
{
    class MergeSort : SortEngine
    {
        SortProject form;
        Visualizer visualizer;

        public MergeSort()
        {
            form = SortProject.instance;
            visualizer = form.vslz;
        }

        public void Sort()
        {
            visualizer.Reset();

            Font f = new Font(FontFamily.GenericSansSerif, 20f, FontStyle.Regular, GraphicsUnit.Pixel);
            visualizer.WriteString("Các số được hightlight màu lên là các số đang được sort", f, Color.Black, new Point(0, 100));

            MS(form.list, 0, form.list.Count - 1);

            visualizer.Reset();
            visualizer.DrawAllItems();
            MessageBox.Show("Đã sắp xếp xong!", "Thông báo!");
        }

        private void MS(List<Item> arr, int left, int right)
        {
            
            if (left < right)
            {
                int middle = left + (right - left) / 2;

                FillingColor(left, middle);
                MS(arr, left, middle);

                FillingColor(middle + 1, right);
                MS(arr, middle + 1, right);

                FillingColor(left, right);
                Merge(arr, left, middle, right);

                visualizer.DrawAllItems();
            }    
        }

        private void Merge(List<Item> arr, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            List<int> L = new List<int>();
            List<int> R = new List<int>();

            int i, j;

            for (i = 0; i < n1; ++i)
            {
                L.Add(arr[left + i].data);
            }    
            for (j = 0; j < n2; ++j)
            {
                R.Add(arr[middle + 1 + j].data);
            }

            i = 0;
            j = 0;

            int k = left;

            while (i < n1 && j < n2)
            {
                if (L[i] * form.sortOrder <= R[j] * form.sortOrder)
                {
                    arr[k].data = L[i];
                    i++;
                }
                else
                {
                    arr[k].data = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                arr[k].data = L[i];

                i++;
                k++;
            }

            while (j < n2)
            {
                arr[k].data = R[j];

                j++;
                k++;
            }

            for (int n = left; n <= right; n++)
            {
                visualizer.ResetColor(form.list[n]);
            }

            visualizer.DrawAllItems();
            Thread.Sleep(form.speed());
        }

        private void FillingColor(int start, int end)
        {
            Random rand = new Random();
            Color color = Color.FromArgb(rand.Next(50, 255), rand.Next(50, 255), rand.Next(50, 255));
            for (int i = start; i <= end; i++)
            {
                form.list[i].backgroundColor = color;
            }

            visualizer.DrawAllItems();
            Thread.Sleep(form.speed());
        }
    }
}
