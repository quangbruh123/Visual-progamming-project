﻿using System;
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

namespace Da_projekt
{
    /// <summary>
    /// Interaction logic for SelectionSortSim.xaml
    /// </summary>
    public partial class SelectionSortSim : Page
    {
        SortSimulation sm;
        Random rand = new Random();
        List<Item> items;
        List<Item> result; //mảng lưu kq sau khi sort.
        int kq; //thời gian sort.
        bool first = true;

        ~SelectionSortSim()
        {
            MessageBox.Show("hlfsahfkjadshfkj");
        }

        public SelectionSortSim(List<Item> Refitems, SortType type)
        {
            InitializeComponent();

            items = Refitems;
            switch (type)
            {
                case SortType.BubbleSort:
                    PageLabel.Content = "Bubble Sort";
                    sm = new SortSimulation(SortType.BubbleSort, MainCanvas, items);
                    break;
                case SortType.InsertionSort:
                    PageLabel.Content = "Insertion Sort";
                    sm = new SortSimulation(SortType.InsertionSort, MainCanvas, items);
                    break;
                case SortType.InterchangeSort:
                    PageLabel.Content = "Interchange Sort";
                    sm = new SortSimulation(SortType.InterchangeSort, MainCanvas, items);
                    break;
                case SortType.MergeSort:
                    PageLabel.Content = "Merge Sort";
                    MessageBox.Show("Tính năng chưa sẵn sàng.");
                    break;
                case SortType.Quicksort:
                    PageLabel.Content = "Quick Sort";
                    sm = new SortSimulation(SortType.Quicksort, MainCanvas, items);
                    break;
                case SortType.SelectionSort:
                    PageLabel.Content = "Selection Sort";
                    sm = new SortSimulation(SortType.SelectionSort, MainCanvas, items);
                    break;
                default:
                    return;
            }
            Save.IsEnabled = false;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            result = sm.CreateCopy(items);
            kq = sm.SortWithResult(ref result);
            sm.Replay();
            Save.IsEnabled = true;

            string s = "";
            foreach (Item i in result)
            {
                s += i.data.ToString() + " ";
            }
            Start.IsEnabled = false;
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            sm.Stop();
            sm = null;
            Window1.instance.MainContentFrame.Content = null;
            Window1.instance.MainContentFrame.Navigate(new Uri("RunSortPage.xaml", UriKind.Relative));
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            List<string> Save = new List<string>();
            string str = "";
            foreach (Item i in items)
            {
                str += i.data.ToString() + " ";
            }
            Save.Add(str);
            str = "";
            foreach (Item i in result)
            {
                str += i.data.ToString() + " ";
            }
            Save.Add(str);
            str = "Thời gian sort: " + kq.ToString() + "ms.";
            Save.Add(str);
            FileManager.fileManager.Save(Save.ToArray());
        }

        private void MainCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (first)
            {
                sm.Initialize2();
                first = false;
            }
        }
    }
}