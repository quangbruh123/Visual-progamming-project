using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Da_projekt
{
    class MergeSort : SortEngine
    {
        List<Item> itemsCopy;
        List<MergeTodo> todos;
        MergeSortSimulation sm;
        List<List<Item>> capture = new List<List<Item>>();
        List<Item> copy;
        TextBox textBox;
        public MergeSort(MergeSortSimulation sortsim, ref List<Item> refitem, ref List<MergeTodo> reftodo, ref List<SubArray> subs, TextBox t = null)
        {
            textBox = t;
            itemsCopy = new List<Item>(refitem);
            todos = reftodo;
            sm = sortsim;
            for (int i = 0; i < subs.Count; i++)
            {
                capture.Add(null);
            }
        }

        public int SortAsMethod()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            todos.Add(new MergeTodo("Refresh"));
            MS(itemsCopy, 0, itemsCopy.Count - 1, 1, 0);
            todos.Add(new MergeTodo("ResetColor"));
            sw.Stop();
            return ((int)sw.ElapsedMilliseconds);//trả về thời gian sort.
        }

        public void SortWithDescription()
        {
            todos.Add(new MergeTodo("MergeInfo", textBox));
            todos.Add(new MergeTodo("Refresh"));
            MS(itemsCopy, 0, itemsCopy.Count - 1, 1, 0);
        }    

        public int SortWithResult(ref List<Item> items)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            todos.Add(new MergeTodo("Refresh"));
            MS(items, 0, items.Count - 1, 1, 0);
            sw.Stop();
            return ((int)sw.ElapsedMilliseconds);//trả về thời gian sort.
        }

        private void MS(List<Item> items, int l, int r, int row, int arrange)
        {
            if (arrange == 0)
            { }
            else if (arrange % 2 == 0)
            {
                todos.Add(new MergeTodo("SelectR", textBox));
            }
            else
            {
                todos.Add(new MergeTodo("SelectL", textBox));
            }

            if (arrange != 0)
                todos.Add(new MergeTodo("Refresh"));
            // arrage là để định xem 2 mảng con đó là mảng con bên trái hay phải CỦA MẢNG MẸ NÀO
            // row là tính số dòng
            if (l < r)
            {
                int m = l + (r - l) / 2;

                todos.Add(new MergeTodo("Split", textBox));
                todos.Add(new MergeTodo("AddSubArray", l, m, 2 * arrange + 1, row + 1));
                todos.Add(new MergeTodo("AddSubArray", m + 1, r, 2 * arrange + 2, row + 1));
                //subArrays[2 * arrage + 1] = new SubArray(items, l, m, row + 1);
                //subArrays[2 * arrage + 2] = new SubArray(items, m + 1, r, row + 1);
                todos.Add(new MergeTodo("Refresh"));
                MS(items, l, m, row + 1, 2 * arrange + 1);

                MS(items, m + 1, r, row + 1, 2 * arrange + 2);

                todos.Add(new MergeTodo("Merge", textBox));
                todos.Add(new MergeTodo("Refresh"));
                merge(items, l, m, r);
                Copy(items);
                AddItemsIntoCapture(copy, arrange);
                todos.Add(new MergeTodo("Update", arrange, capture[arrange]));
                todos.Add(new MergeTodo("ChangeColor", l, r, arrange, row));
                todos.Add(new MergeTodo("DeleteSubArray", 2 * arrange + 1));
                todos.Add(new MergeTodo("DeleteSubArray", 2 * arrange + 2));
                //subArrays[2 * arrage + 1] = null;
                //subArrays[2 * arrage + 2] = null;
                todos.Add(new MergeTodo("Refresh"));
            }
            else
            {
                row--;
                todos.Add(new MergeTodo("Ready", textBox));
                todos.Add(new MergeTodo("ChangeColor", l, r, arrange, row));
                todos.Add(new MergeTodo("Refresh"));
            }
        }

        private void merge(List<Item> items, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;

            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;


            for (i = 0; i < n1; ++i)
                L[i] = items[l + i].data;
            for (j = 0; j < n2; ++j)
                R[j] = items[m + 1 + j].data;

            i = 0;
            j = 0;

            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    items[k].data = L[i];
                    i++;
                }
                else
                {
                    items[k].data = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                items[k].data = L[i];
                i++;
                k++;
            }

            // Copy remaining elements
            // of R[] if any
            while (j < n2)
            {
                items[k].data = R[j];
                j++;
                k++;
            }

        }
        private void Copy(List<Item> items)
        {
            copy = new List<Item>();
            for (int i = 0; i < items.Count; i++)
            {
                Item tmp = new Item(items[i]);
                copy.Add(tmp);
            }    
        }

        private void AddItemsIntoCapture(List<Item> items, int arrange)
        {
            capture[arrange] = new List<Item>();
            for (int i = 0; i < items.Count; i++)
            {
                capture[arrange].Add(items[i]);
            }    
        }

        public void SortAsThread()
        {

        }
    }

    //void merge(int[] arr, int l, int m, int r)
    //{
    //    // Find sizes of two
    //    // subarrays to be merged
    //    int n1 = m - l + 1;
    //    int n2 = r - m;

    //    // Create temp arrays
    //    int[] L = new int[n1];
    //    int[] R = new int[n2];
    //    int i, j;

    //    // Copy data to temp arrays
    //    for (i = 0; i < n1; ++i)
    //        L[i] = arr[l + i];
    //    for (j = 0; j < n2; ++j)
    //        R[j] = arr[m + 1 + j];

    //    // Merge the temp arrays

    //    // Initial indexes of first
    //    // and second subarrays
    //    i = 0;
    //    j = 0;

    //    // Initial index of merged
    //    // subarray array
    //    int k = l;
    //    while (i < n1 && j < n2)
    //    {
    //        if (L[i] <= R[j])
    //        {
    //            arr[k] = L[i];
    //            i++;
    //        }
    //        else
    //        {
    //            arr[k] = R[j];
    //            j++;
    //        }
    //        k++;
    //    }

    //    // Copy remaining elements
    //    // of L[] if any
    //    while (i < n1)
    //    {
    //        arr[k] = L[i];
    //        i++;
    //        k++;
    //    }

    //    // Copy remaining elements
    //    // of R[] if any
    //    while (j < n2)
    //    {
    //        arr[k] = R[j];
    //        j++;
    //        k++;
    //    }
    //}

    //// Main function that
    //// sorts arr[l..r] using
    //// merge()
    //void sort(int[] arr, int l, int r)
    //{
    //    if (l < r)
    //    {
    //        // Find the middle
    //        // point
    //        int m = l + (r - l) / 2;

    //        // Sort first and
    //        // second halves
    //        sort(arr, l, m);
    //        sort(arr, m + 1, r);

    //        // Merge the sorted halves
    //        merge(arr, l, m, r);
    //    }
    //}
}
