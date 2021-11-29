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
        public SortSimulation sm;
        public MergeSortSimulation mergeSortSimulation;
        Random rand = new Random();
        public List<Item> items = new List<Item>();

        public LearnSortPanel()
        {
            InitializeComponent();

            instance = this;
            for (int i = 0; i < 10; i++)
            {
                Item item = new Item(rand.Next(10, 100));

                items.Add(item);
            }
            sm = new SortSimulation(MainCanvas, items);
        }

        //bắt buộc phải sử dụng LearnSortPanel.instance.refresh() thay vì sm.refresh() nếu sort bằng thread. ko cần thiết nếu ko dùng thread
        public void refresh(List<Item> refitems)//vẽ ra màn hình mảng đã sort hay mang đang minh họa sort?
        {
            Application.Current.Dispatcher.BeginInvoke(
            DispatcherPriority.Background,new Action(() => {
                sm.refresh(refitems);
            }));
        }
        public void Refresh(List<SubArray> subArrays)//vẽ ra màn hình mảng đã sort hay mang đang minh họa sort?
        {
            Application.Current.Dispatcher.BeginInvoke(
            DispatcherPriority.Background, new Action(() => {
                mergeSortSimulation.DrawSubArray(subArrays);
            }));
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            sm.MethodSort();
            sm.ManualReplay();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sm.isPausing)
            {
                sm.isPausing = false;
            } else
            {
                sm.isPausing = true;
            }
        }
    }
}
