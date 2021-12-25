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
using System.Threading;

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
        List<string> SaveData = new List<string>();
        int kq; //thời gian sort.
        bool first = true;
        SortType sortType;
        Thread t;

        public SelectionSortSim(List<Item> Refitems, SortType type)
        {
            InitializeComponent();

            items = Refitems;
            sortType = type;
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
                    sm = new SortSimulation(SortType.MergeSort, MainCanvas, items);
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
            sm.refresh2(items);
            Save.IsEnabled = false;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            sm.sortingScreen(MainCanvas);
            result = sm.CreateCopy(items);

            Start.IsEnabled = false;

            if (items.Count <= 250)
            {
                kq = sm.SortWithResult(ref result);

                Save.IsEnabled = true;
                string s = "";
                foreach (Item i in result)
                {
                    s += i.data.ToString() + " ";
                }

                sm.Replay();
            }
            else
            {
                t = new Thread(sort);
                t.IsBackground = true;
                t.Start();
            }
            
        }

        private void sort()
        {
            kq = sm.SortWithResultOnly(ref result);
            refresh(result);
        }

        public void refresh(List<Item> refitems)
        {
            this.Dispatcher.Invoke(() => {
                Save.IsEnabled = true;
                DrawingVisual drawingVisual = new DrawingVisual();
                DrawingContext drawingContext = drawingVisual.RenderOpen();

                float spacing = ((float)MainCanvas.ActualWidth) / ((float)(refitems.Count));

                //Rect background = new Rect(new Point(0, 0), new Point(screen.ActualWidth, screen.ActualHeight));
                //drawingContext.DrawRectangle(Brushes.Black, new Pen(Brushes.White, 0f), background);

                for (int i = 0; i < refitems.Count; i++)
                {
                    Point lcnr = new Point(spacing * i, MainCanvas.ActualHeight - refitems[i].data - 1);
                    Point rcnr = new Point(spacing * (i + 1), MainCanvas.ActualHeight);
                    Rect drawspace = new Rect(lcnr, rcnr);
                    refitems[i].drawItemWithoutTextSelectionSort(drawingContext, drawspace);
                }

                drawingContext.Close();

                DrawingBrush db = new DrawingBrush(drawingVisual.Drawing);
                MainCanvas.Background = db;
            });
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
            MessageBox.Show("Đang lưu lại thành file, vui lòng chờ...");
            SaveData.Add("Kết quả: ");
            string str = "";
            foreach (Item i in result)
            {
                str += i.data.ToString() + " ";
            }
            SaveData.Add(str);

            switch (sortType)
            {
                case SortType.BubbleSort:
                    str = "Phương pháp Bubble Sort: " + kq.ToString() + "ms.";
                    break;
                case SortType.InsertionSort:
                    str = "Phương pháp Insertion Sort: " + kq.ToString() + "ms.";
                    break;
                case SortType.InterchangeSort:
                    str = "Phương pháp Interchange Sort: " + kq.ToString() + "ms."; 
                    break;
                case SortType.MergeSort:
                    str = "Phương pháp Merge Sort: " + kq.ToString() + "ms."; 
                    break;
                case SortType.Quicksort:
                    str = "Phương pháp Quick Sort: " + kq.ToString() + "ms."; 
                    break;
                case SortType.SelectionSort:
                    str = "Phương pháp Selection Sort: " + kq.ToString() + "ms."; 
                    break;
                default:
                    return;
            }
            SaveData.Add(str);
            FileManager.fileManager.Save(SaveData.ToArray());
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
