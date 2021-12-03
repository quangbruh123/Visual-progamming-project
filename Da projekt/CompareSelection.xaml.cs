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
using System.IO;
using Microsoft.Win32;

namespace Da_projekt
{
    /// <summary>
    /// Interaction logic for CompareSelection.xaml
    /// </summary>
    public partial class CompareSelection : Page
    {
        bool first = true;
        bool ignore = false;
        int sortIndex = 0, 
            inputIndex = 0;
        TextBox t;
        string input = "";

        public CompareSelection()
        {
            InitializeComponent();
            SortView.ScrollToVerticalOffset(0);
            SwitchTo(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Item> items = new List<Item>();

            switch (inputIndex)
            {
                case 0:
                    {
                        items = new List<Item>();

                        string[] txt = t.Text.Split(' ');
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
                        int n = int.Parse(t.Text);
                        for (int i = 0; i < n; i++)
                        {
                            Item item = new Item(rand.Next(10, 100));

                            items.Add(item);
                        }
                    }
                    break;
                case 2:
                    {
                        if (input == "")
                        {
                            MessageBox.Show("Chưa chọn file hoặc File trống.");
                            return;
                        } else
                        {
                            items = new List<Item>();

                            string[] txt = input.Split(' ');
                            foreach (string str in txt)
                            {
                                Item item = new Item(int.Parse(str));

                                items.Add(item);
                            }
                        }
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
            SwitchTo(Selection.SelectedIndex);
        }

        private void SwitchTo(int index)
        {
            switch (index)
            {
                case 0:
                    {
                        InputContainer.Children.Clear();
                        inputIndex = 0;

                        Label lb = new Label();
                        lb.Content = "Nhập dữ liệu vào: ";
                        lb.Margin = new Thickness(0, 10, 0, 0);

                        TextBox tb = new TextBox();
                        tb.HorizontalAlignment = HorizontalAlignment.Stretch;
                        tb.TextWrapping = TextWrapping.NoWrap;
                        tb.Margin = new Thickness(0, 10, 0, 0);
                        tb.Height = 20;

                        t = tb;

                        InputContainer.Children.Add(lb);
                        InputContainer.Children.Add(tb);
                    }
                    break;
                case 1:
                    {
                        InputContainer.Children.Clear();
                        inputIndex = 1;

                        Label lb = new Label();
                        lb.Content = "Nhập số lượng phần tử dữ liệu vào: ";
                        lb.Margin = new Thickness(0, 10, 0, 0);

                        TextBox tb = new TextBox();
                        tb.HorizontalAlignment = HorizontalAlignment.Stretch;
                        tb.TextWrapping = TextWrapping.NoWrap;
                        tb.Margin = new Thickness(0, 10, 0, 0);
                        tb.Height = 20;
                        tb.TextAlignment = TextAlignment.Right;

                        t = tb;

                        InputContainer.Children.Add(lb);
                        InputContainer.Children.Add(tb);
                    }
                    break;
                case 2:
                    {
                        /*InputContainer.Children.Clear();
                        inputIndex = 2;

                        Label lb = new Label();
                        lb.Content = "Chọn đường dẫn file";
                        lb.Margin = new Thickness(0, 10, 0, 0);

                        Button btn = new Button();
                        btn.Background = Brushes.White;
                        btn.Content = "Chọn file:";
                        btn.HorizontalContentAlignment = HorizontalAlignment.Left;
                        btn.Margin = new Thickness(0, 10, 0, 0);
                        btn.Click += Open_click;

                        InputContainer.Children.Add(lb);
                        InputContainer.Children.Add(btn);*/

                        InputContainer.Children.Clear();
                        inputIndex = 2;

                        Label lb = new Label();
                        lb.Content = "Chọn đường dẫn file";
                        lb.Margin = new Thickness(0, 10, 0, 0);

                        ComboBox cb = new ComboBox();
                        
                        foreach (string s in Window1.instance.fm.files)
                        {
                            ComboBoxItem cbi = new ComboBoxItem();
                            cbi.Content = s;
                            cb.Items.Add(cbi);
                        }
                        ComboBoxItem cbl = new ComboBoxItem();
                        cbl.Content = "Chọn file khác...";
                        cb.Items.Add(cbl);
                        cb.SelectionChanged += cb_SelectionChanged;

                        InputContainer.Children.Add(lb);
                        InputContainer.Children.Add(cb);
                    }
                    break;
            }
        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!ignore)
            {
                ComboBox cb = sender as ComboBox;
                ComboBoxItem cbi = cb.SelectedItem as ComboBoxItem;
                string filepath = FileManager.fileManager.GetDirectory(cbi.Content as string);
                if (cbi.Content.ToString() != "Chọn file khác...")
                {
                    input = FileManager.fileManager.Read(filepath);
                }
                else
                {
                    ignore = true;
                    ComboBoxItem cbl = cb.Items[cb.Items.Count - 1] as ComboBoxItem;
                    if (cbl.Content.ToString() != "Chọn file khác...")
                    {
                        cb.Items.Remove(cbl);
                    }

                    string n = "";
                    input = FileManager.fileManager.Open(ref n);
                    ComboBoxItem c = new ComboBoxItem();
                    c.Content = n;
                    cb.Items.Add(c);
                    cb.SelectedItem = c;
                    ignore = false;
                }
            }
        }

        /*private void Open_click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                btn.Content = openFileDialog.FileName;
                input = System.IO.File.ReadAllText(openFileDialog.FileName);
            }
        }   */

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (SortView.VerticalOffset < SortView.ScrollableHeight)
            {
                sortIndex++;
                SortView.ScrollToVerticalOffset(SortView.VerticalOffset + SortList.ActualHeight / 3);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (SortView.VerticalOffset > 0)
            {
                sortIndex--;
                SortView.ScrollToVerticalOffset(SortView.VerticalOffset - SortList.ActualHeight / 3);
            }
        }
    }
}
