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
using System.Windows.Threading;

namespace Da_projekt
{
    /// <summary>
    /// Interaction logic for LearnSortPanel.xaml
    /// </summary>
    ///
    public partial class LearnSortPage : Page
    {
        MergeSortSimulation mss;
        SortSimulation sm;
        Random rand = new Random();
        List<Item> items = new List<Item>();
        public bool isStarted = false;
        bool first = true;

        public LearnSortPage(SortType st)
        {
            InitializeComponent();

            for (int i = 0; i < Window1.instance.exampleCount; i++)
            {
                Item item = new Item(rand.Next(10, 100));

                items.Add(item);
            }
            switch (st)
            {
                case SortType.BubbleSort:
                    PageLabel.Content = "Bubble Sort";
                    sm = new SortSimulation(SortType.BubbleSort, MainCanvas, items, TextDisplay);
                    break;
                case SortType.InsertionSort:
                    PageLabel.Content = "Insertion Sort";
                    sm = new SortSimulation(SortType.InsertionSort, MainCanvas, items, TextDisplay);
                    break;
                case SortType.InterchangeSort:
                    PageLabel.Content = "Interchange Sort";
                    sm = new SortSimulation(SortType.InterchangeSort, MainCanvas, items, TextDisplay);
                    break;
                case SortType.MergeSort:
                    PageLabel.Content = "Merge Sort";
                    mss = new MergeSortSimulation(MainCanvas, items, TextDisplay);
                    break;
                case SortType.Quicksort:
                    PageLabel.Content = "Quick Sort";
                    sm = new SortSimulation(SortType.Quicksort, MainCanvas, items, TextDisplay);
                    break;
                case SortType.SelectionSort:
                    PageLabel.Content = "Selection Sort";
                    sm = new SortSimulation(SortType.SelectionSort, MainCanvas, items, TextDisplay);
                    break;
                default:
                    return;
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if (Start.Content.ToString() == "Hoàn tất")
            {
                return;
            }
            if (isStarted == false)
            {
                Start.Content = "Bước tiếp ";
                List<Item> k = new List<Item>();
                if (sm != null)
                {
                    sm.SortWithResult(ref k);
                    sm.ManualReplay();
                }
                else if (mss != null)
                {
                    mss.MethodSort();
                }
                isStarted = true;
            }
            else
            {
                if (sm != null)
                {
                    sm.Pause();
                }
                else if (mss != null)
                {
                    if (mss.isPaused)
                    {
                        mss.isPaused = false;
                        //sm.isPausing = false;
                    }
                    else
                    {
                        mss.isPaused = true;
                        //sm.isPausing = true;
                    }
                }
            }
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            if (sm != null)
            {
                sm.Stop();
                sm = null;
            }
            else if (mss != null)
            {
                mss = null;
            }
            Window1.instance.MainContentFrame.Content = null;
            Window1.instance.MainContentFrame.Navigate(new Uri("LearnSortMenu.xaml", UriKind.Relative));
        }

        private void MainCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (first)
            {
                if (sm != null)
                    sm.Initialize();
                else if (mss != null)
                    mss.Initialize();
                first = false;
            }
        }
    }
}
