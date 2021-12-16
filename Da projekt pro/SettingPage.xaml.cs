using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace Da_projekt
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class SettingPage : Page
    {
        string NewDirectory = "";

        public SettingPage()
        {
            InitializeComponent();
            this.RenderSize = SettingWindow.instance.MainContentFrame.RenderSize;
            output.Content = FileManager.fileManager.inputDir;
            exampleCount.Text = Window1.instance.exampleCount.ToString();
            minValue.Text = Window1.instance.minValue.ToString();
            maxValue.Text = Window1.instance.maxValue.ToString();
        }

        private bool tmdk()
        {
            int m;
            int n;
            int k;
            if (NewDirectory == null)
            {
                System.Windows.MessageBox.Show("Thư mục không hợp lệ!");

                return false;
            }
            if (!Int32.TryParse(minValue.Text, out m) || m <= 0)
            {
                System.Windows.MessageBox.Show("Giá trị nhỏ nhất phải là số nguyên dương");

                return false;
            }
            if (!Int32.TryParse(maxValue.Text, out n) || n <= 0)
            {
                System.Windows.MessageBox.Show("Giá trị lớn nhất phải là số nguyên dương");

                return false;
            }
            if (!Int32.TryParse(exampleCount.Text, out k) || k <= 0)
            {
                System.Windows.MessageBox.Show("Giá trị số phần tử phải là số nguyên dương");

                return false;
            }
            if (m > n)
            {
                System.Windows.MessageBox.Show("Giá trị lớn nhất phải lớn hơn giá trị nhỏ nhất");

                return false;
            }
            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tmdk())
            {
                FileManager.fileManager.inputDir = NewDirectory;
                Window1.instance.exampleCount = int.Parse(exampleCount.Text);
                Window1.instance.minValue = int.Parse(minValue.Text);
                Window1.instance.maxValue = int.Parse(maxValue.Text);
            }
            SettingWindow.instance.Close();
        }

        private void output_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button btn = sender as System.Windows.Controls.Button;

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                NewDirectory = fbd.SelectedPath;
                btn.Content = fbd.SelectedPath;
            }
        }
    }
}
