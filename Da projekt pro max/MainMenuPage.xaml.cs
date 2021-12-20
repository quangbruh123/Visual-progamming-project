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
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {

        public MainMenuPage()
        {
            InitializeComponent();
            this.RenderSize = Window1.instance.MainContentFrame.RenderSize;
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            Window1.instance.MainContentFrame.Navigate(new Uri("WelcomePage.xaml", UriKind.Relative));
        }


        private void btnSVisualizer_Click(object sender, RoutedEventArgs e)
        {
            Window1.instance.MainContentFrame.Navigate(new Uri("LearnSortMenu.xaml", UriKind.Relative));
        }

        private void btnSimulation_Click(object sender, RoutedEventArgs e)
        {
            Window1.instance.MainContentFrame.Navigate(new Uri("RunSortPage.xaml", UriKind.Relative));
        }

        private void btnAutomatic_Click(object sender, RoutedEventArgs e)
        {
            Window1.instance.MainContentFrame.Navigate(new Uri("CompareSortPage.xaml", UriKind.Relative));
        }
    }
}
