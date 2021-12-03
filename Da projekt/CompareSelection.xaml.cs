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
    /// Interaction logic for CompareSelection.xaml
    /// </summary>
    public partial class CompareSelection : Page
    {
        bool first = true;
        int sortIndex = 0, 
            inputIndex = 0;
        TextBox t;

        public CompareSelection()
        {
            InitializeComponent();
            SortList.SelectedIndex = 0;
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            List<Item> items = new List<Item>();

            switch (inputIndex)
            {
                case 0:
                    {
                        items = new List<Item>();

                        string[] txt = tbxInput.Text.Split(' ');
                        foreach (string str in txt)
                        {
                            Item item = new Item(int.Parse(str));

                            items.Add(item);
                        }
                    }
                    break;
                case 1:
                    {
                        items = new List<Item>();

                        Random rand = new Random();
                        int n = int.Parse(tbxInput.Text);
                        for (int i = 0; i < n; i++)
                        {
                            Item item = new Item(rand.Next(10, 100));

                            items.Add(item);
                        }
                    }
                    break;
                case 2:
                    {
                        MessageBox.Show("Tính năng chưa sẵn sàng!");
                    }
                    break;
            }
            switch (sortIndex)
            {
                case 0:
                    {
                        Window1.instance.MainContentFrame.Content = new SelectionSortSim(items);
                    }
                    break;
                case 1:
                    {
                        MessageBox.Show("Tính năng chưa sẵn sàng!");
                        //Window1.instance.MainContentFrame.Content = new SelectionSortSim(items);
                    }
                    break;
                case 2:
                    {
                        MessageBox.Show("Tính năng chưa sẵn sàng!");
                        //Window1.instance.MainContentFrame.Content = new SelectionSortSim(items);

                    }
                    break;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (first)
            {
                first = false;
                return;
            }
            tbxInput.Clear();
            switch (Selection.SelectedIndex)
            {
                case 0:
                    {
                        inputIndex = 0;
                        lbInput.Content = "Nhập các phần tử cần sắp xếp, cách nhau 1 khoảng trắng:";

                    }
                    break;
                case 1:
                    {
                        inputIndex = 1;
                        lbInput.Content = "Nhập số lượng phần tử cần sắp xếp:";
                    }
                    break;
                case 2:
                    {
                        inputIndex = 2;
                        lbInput.Content = "Tính năng chưa sẵn sàng!";
                    }
                    break;
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (SortList.SelectedIndex == 1)
                return;
            sortIndex++;
            SortList.SelectedIndex++;
            SortList.ScrollIntoView(SortList.SelectedItem);
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            Window1.instance.MainContentFrame.Content = new Page2();
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (SortList.SelectedIndex == 0)
                return;
            sortIndex--;
            SortList.SelectedIndex--;
            SortList.ScrollIntoView(SortList.SelectedItem);
        }
    }
}
