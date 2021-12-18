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
using System.Windows.Shapes;

namespace Da_projekt
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public static Window1 instance;

        public int minValue = 1;
        public int maxValue = 999;
        public int exampleCount = 10;
        public FileManager fm = new FileManager("C:\\");

        public Window1()
        {
            //Tắt Splashscreen
            App.ss.Close(TimeSpan.FromSeconds(0.2));

            InitializeComponent();
            instance = this;

            MainContentFrame.Navigate(new Uri("WelcomePage.xaml", UriKind.Relative));
        }
    }
}
