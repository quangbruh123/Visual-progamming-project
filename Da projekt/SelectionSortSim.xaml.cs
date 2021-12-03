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
    public partial class SelectionSortSim : Page
    {
        public static SelectionSortSim instance;
        public SortSimulation sm;
        public bool isStarted = false;
        Random rand = new Random();
        List<Item> items;

        public SelectionSortSim(List<Item> Refitems)
        {
            InitializeComponent();
            instance = this;

            items = Refitems;
            sm = new SortSimulation(MainCanvas, items);
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            sm.MethodSort();
            sm.Replay();
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            Window1.instance.MainContentFrame.Content = new CompareSelection();
        }
    }
}
