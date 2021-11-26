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
    public partial class LearnSortPanel : Page
    {
        public static LearnSortPanel instance;
        public MergeSortSimulation mergeSortSimulation;
        public SortSimulation sm;
        Random rand = new Random();
        public List<Item> items = new List<Item>();

        public LearnSortPanel()
        {
            InitializeComponent();

            instance = this;
            for (int i = 0; i < 8; i++)
            {
                Item item = new Item(rand.Next(10, 100));

                items.Add(item);
            }
            //Item item = new Item(12);
            //items.Add(item);
            //Item item2 = new Item(11);
            //items.Add(item2);
            //Item item3 = new Item(13);
            //items.Add(item3);
            //Item item4 = new Item(5);
            //items.Add(item4);
            mergeSortSimulation = new MergeSortSimulation(MainCanvas, items);
        }

        //bắt buộc phải sử dụng LearnSortPanel.instance.refresh() thay vì sm.refresh() nếu sort bằng thread. ko cần thiết nếu ko dùng thread
        public void Refresh(List<SubArray> subArrays)//vẽ ra màn hình mảng đã sort hay mang đang minh họa sort?
        {
            Application.Current.Dispatcher.BeginInvoke(
            DispatcherPriority.Background,new Action(() => {
                mergeSortSimulation.DrawSubArray(subArrays);
            }));
        }
        public void refresh(List<Item> refitems)//vẽ ra màn hình mảng đã sort hay mang đang minh họa sort?
        {
            Application.Current.Dispatcher.BeginInvoke(
            DispatcherPriority.Background, new Action(() => {
                sm.refresh(refitems);
            }));
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            mergeSortSimulation.MethodSort();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (mergeSortSimulation.isPaused)
            {
                mergeSortSimulation.isPaused = false;
            }
            else
            {
                mergeSortSimulation.isPaused = true;
            }
        }
    }
}
