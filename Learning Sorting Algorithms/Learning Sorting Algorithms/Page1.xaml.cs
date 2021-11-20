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

namespace Learning_Sorting_Algorithms
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }
        private void Button_Guess_Login_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.instance.MainContentFrame.Content = new Page2();
        }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.instance.MainContentFrame.Content = new Page3();
        }

        private void Button_Sign_Up_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.instance.MainContentFrame.Content = new Page4();
        }
    }
}
