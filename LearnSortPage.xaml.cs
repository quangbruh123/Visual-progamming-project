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
        public static LearnSortPage instance;
        public SortSimulation sm;
        Random rand = new Random();
        public List<Item> items = new List<Item>();
        public bool isStarted = false;

        public LearnSortPage(SortType st)
        {
            InitializeComponent();

            instance = this;
            for (int i = 0; i < 100; i++)
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
                    MessageBox.Show("Tính năng chưa sẵn sàng.");
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
                sm.SortWithResult(ref k);
                sm.Replay();
                isStarted = true;
            }
            else
            {
                sm.Pause();
            }
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            Window1.instance.MainContentFrame.Content = new LearnSortMenu();
        }
    }
}
