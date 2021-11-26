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
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
            this.RenderSize = Window1.instance.MainContentFrame.RenderSize;
        }

        private void ComparisionGroup_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Window1.instance.MainContentFrame.Content = new Page1();
        }

        private void Learn_Click(object sender, RoutedEventArgs e)
        {
            Window1.instance.MainContentFrame.Content = new LearnCode();
        }

        private void LearnGroup_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
