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
    public partial class LearnCode : Page
    {
        public LearnCode()
        {
            InitializeComponent();
        }

        private void Selection_Click(object sender, RoutedEventArgs e)
        {
            Window1.instance.MainContentFrame.Content = new LearnSortPanel();
        }
        private void Return_Click(object sender, RoutedEventArgs e)
        {
            Window1.instance.MainContentFrame.Content = new Page2();
        }
    }
}
