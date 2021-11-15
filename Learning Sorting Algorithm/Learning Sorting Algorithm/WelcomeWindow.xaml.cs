using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Learning_Sorting_Algorithm
{
    /// <summary>
    /// Interaction logic for WelcomeWindow.xaml
    /// </summary>
    public partial class WelcomeWindow : Window
    {
        public static WelcomeWindow instance;
        public WelcomeWindow()
        {
            InitializeComponent();
            instance = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Guess_Login_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.instance.Show();
            this.Hide();
        }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Sign_Up_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
