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
    public partial class WelcomePage : Page
    {
        public WelcomePage()
        {
            InitializeComponent();
            this.RenderSize = Window1.instance.MainContentFrame.RenderSize;
            output.Content = FileManager.fileManager.inputDir;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1.instance.MainContentFrame.Content = new MainMenuPage();
        }

        private void output_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button btn = sender as System.Windows.Controls.Button;

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                FileManager.fileManager.SetNewInputDir(fbd.SelectedPath);
                btn.Content = fbd.SelectedPath;
            }
        }
    }
}
