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
    /// Interaction logic for LearnCode.xaml
    /// </summary>
    public partial class LearnSortMenu : Page
    {
        public LearnSortMenu()
        {
            InitializeComponent();
        }

        private void Selection_Click(object sender, RoutedEventArgs e)
        {
            Window1.instance.MainContentFrame.Navigate(new LearnSortPage(SortType.SelectionSort));
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            Window1.instance.MainContentFrame.Navigate(new Uri("MainMenuPage.xaml", UriKind.Relative));
        }

        private void Merge_Click(object sender, RoutedEventArgs e)
        {
            Window1.instance.MainContentFrame.Navigate(new LearnSortPage(SortType.MergeSort));
        }

        private void Bubble_Click(object sender, RoutedEventArgs e)
        {
            Window1.instance.MainContentFrame.Navigate(new LearnSortPage(SortType.BubbleSort));
        }

        private void Interchange_Click(object sender, RoutedEventArgs e)
        {
            Window1.instance.MainContentFrame.Navigate(new LearnSortPage(SortType.InterchangeSort));
        }

        private void Quick_Click(object sender, RoutedEventArgs e)
        {
            Window1.instance.MainContentFrame.Navigate(new LearnSortPage(SortType.Quicksort));
        }

        private void Insertion_Click(object sender, RoutedEventArgs e)
        {
            Window1.instance.MainContentFrame.Navigate(new LearnSortPage(SortType.InsertionSort));
        }
    }
}
