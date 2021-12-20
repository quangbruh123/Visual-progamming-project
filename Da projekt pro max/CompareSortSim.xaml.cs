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

namespace Da_projekt
{
    /// <summary>
    /// Interaction logic for SelectionSortSim.xaml
    /// </summary>
    public partial class CompareSortSim : Page
    {
        SortSimulation smbackup, sm;
        MergeSortSimulation msm;
        

        Random rand = new Random();
        List<Item> items;
        List<Item> result; //mảng lưu kq sau khi sort.
        int[] kq; //thời gian sort.
        int[] offset; //đừng hỏi

        List<Todo>[] todos;
        bool first = true;
        bool exiting = false;

        public CompareSortSim(List<Item> Refitems)
        {
            InitializeComponent();

            items = Refitems;
            kq = new int[6];
            offset = new int[6];
            todos = new List<Todo>[6];

            Canvas p = new Canvas();
            smbackup = new SortSimulation(SortType.Quicksort, p, items);

            Save.IsEnabled = false;
        }

        private async void Carousel()
        {
            List<Item>[] itemsCopy = new List<Item>[6];
            for (int i = 0; i < 6; i++)
            {
                itemsCopy[i] = smbackup.CreateCopy(items);
                offset[i] = 0;
            }

            int step = 0;
            bool refreshing = false;
            while (isNotDone(step))
            {
                refreshing = false;
                for (int i = 0; i < 6; i++)
                {
                    if (exiting)
                        return;
                    if (todos[i].Count - 1 > (step + offset[i]))
                    {
                        while (todos[i][step + offset[i]].Gettype() == "ResetColor")
                        {
                            todos[i][step + offset[i]].Execute(itemsCopy[i], smbackup);
                            refresh(itemsCopy[i], returnCanvas(i));
                            offset[i]++;
                        }
                        if (todos[i][step + offset[i]].Gettype() == "Refresh")
                        {
                            refresh(itemsCopy[i], returnCanvas(i));
                            refreshing = true;
                        }
                        else
                        {
                            if (i != 5) { todos[i][step + offset[i]].Execute(itemsCopy[i], smbackup); }
                            else todos[i][step + offset[i]].Execute(itemsCopy[i], smbackup, result); ;
                        }
                    }
                }
                step++;
                if (refreshing)
                {
                    await Task.Delay(((int)(1000f / 144)));
                    refreshing = false;
                }
                if (exiting)
                    return;
            }
        }

        private bool isNotDone(int k)
        {
            for (int i = 0; i < 6; i++)
            {
                if (todos[i].Count >= k)
                {
                    return true;
                }
            }
            return false;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            result = smbackup.CreateCopy(items);
            smbackup.SortWithResult(ref result);

            Save.IsEnabled = true;

            Sort();
            Carousel();

            string s = "";
            foreach (Item i in result)
            {
                s += i.data.ToString() + " ";
            }
            Start.IsEnabled = false;
        }

        private void Sort()
        {
            Canvas p = new Canvas();

            sm = new SortSimulation(SortType.SelectionSort, p, items);
            kq[0] = sm.MethodSort();
            todos[0] = sm.GetTodos();

            sm = new SortSimulation(SortType.BubbleSort, p, items);
            kq[1] = sm.MethodSort();
            todos[1] = sm.GetTodos();

            sm = new SortSimulation(SortType.InsertionSort, p, items);
            kq[2] = sm.MethodSort();
            todos[2] = sm.GetTodos();

            sm = new SortSimulation(SortType.InterchangeSort, p, items);
            kq[3] = sm.MethodSort();
            todos[3] = sm.GetTodos();

            sm = new SortSimulation(SortType.Quicksort, p, items);
            kq[4] = sm.MethodSort();
            todos[4] = sm.GetTodos();

            //sm = new SortSimulation(SortType.MergeSort, p, items);
            //kq[5] = sm.MethodSort();
            //todos[5] = sm.GetTodos();

            MessageBox.Show("Xong");

        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            exiting = true;
            sm = null;
            smbackup = null;
            for (int i = 0; i < 6; i++)
            {
                todos[i] = null;
            }
            Window1.instance.MainContentFrame.Content = null;
            Window1.instance.MainContentFrame.Navigate(new Uri("CompareSortPage.xaml", UriKind.Relative));
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
                first = false;
                Initialize();
            }
        }

        public void refresh(List<Item> refitems, Canvas screen)
        {
            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();

            float spacing = ((float)screen.ActualWidth) / ((float)(refitems.Count));

            //Rect background = new Rect(new Point(0, 0), new Point(screen.ActualWidth, screen.ActualHeight));
            //drawingContext.DrawRectangle(Brushes.Black, new Pen(Brushes.White, 0f), background);

            for (int i = 0; i < refitems.Count; i++)
            {
                Point lcnr = new Point(spacing * i, screen.ActualHeight - refitems[i].data - 1);
                Point rcnr = new Point(spacing * (i + 1) - 1, screen.ActualHeight);
                Rect drawspace = new Rect(lcnr, rcnr);
                refitems[i].drawItemWithoutTextSelectionSort(drawingContext, drawspace);
            }

            drawingContext.Close();

            DrawingBrush db = new DrawingBrush(drawingVisual.Drawing);
            screen.Background = db;
        }

        private Canvas returnCanvas(int i)
        {
            switch (i)
            {
                case 0:
                    return Canvas1;
                case 1:
                    return Canvas2;
                case 2:
                    return Canvas3;
                case 3:
                    return Canvas4;
                case 4:
                    return Canvas5;
                case 5:
                    return Canvas6;
                default:
                    return null;
            }
        }

        private void Initialize()
        {
            for (int i = 0; i < 6; i++)
            {
                refresh(items, returnCanvas(i));
            }
        }
    }
}
