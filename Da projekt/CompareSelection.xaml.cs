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
        bool changed = false;
        TextBox t;
        string input = "";
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
                        string[] txt;
                        items = new List<Item>();
                        if (changed == false)
                            txt = tbxInput.Text.Split(' ');
                        else
                            txt = t.Text.Split(' ');
                        foreach (string str in txt)
                        {
                            Item item = new Item(int.Parse(str));

                            items.Add(item);
                        }
                    }
                    break;
                case 1:
                    {
                        int n;
                        items = new List<Item>();
                        if (changed == false)
                            n = int.Parse(tbxInput.Text);
                        else
                            n = int.Parse(t.Text);

                        Random rand = new Random();
                       
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
                changed = false;
                return;
            }
            changed = true;
            tbxInput.Clear();
            switch (Selection.SelectedIndex)
            {
                case 0:
                    {
                        ComboBox cbx = (ComboBox)FindName("cbFile");
                        Grid.Children.Remove(cbx);
                        t = new TextBox();
                        t.Name = "tbxInput";
                        t.SetValue(Grid.RowProperty, 2);
                        t.SetValue(Grid.ColumnProperty, 2);
                        var style = Application.Current.TryFindResource("txblDesign") as Style;
                        t.Style = style;
                        t.VerticalContentAlignment = VerticalAlignment.Center;


                        inputIndex = 0;
                        lbInput.Content = "Nhập các số cần xếp:";
                        Grid.Children.Add(t);
                    }
                    break;
                case 1:
                    {
                        ComboBox cbx = (ComboBox)FindName("cbFile");
                        Grid.Children.Remove(cbx);
                        t = new TextBox();
                        t.Name = "tbxInput";
                        t.SetValue(Grid.RowProperty, 2);
                        t.SetValue(Grid.ColumnProperty, 2);
                        var style = Application.Current.TryFindResource("txblDesign") as Style;
                        t.Style = style;
                        t.VerticalContentAlignment = VerticalAlignment.Center;
                        t.SetValue(NameProperty, "tbxInput");
                        
                        inputIndex = 1;
                        lbInput.Content = "Nhập số lượng phần tử cần sắp xếp:";
                        Grid.Children.Add(t);
                    }
                    break;
                case 2:
                    {
                        inputIndex = 2;
                        TextBox tb = (TextBox)FindName("tbxInput");
                        if (tb != null)
                        {
                            Grid.Children.Remove(tb);
                        }
                        lbInput.Content = "Chọn đường dẫn file";
                        ComboBox cb = new ComboBox();
                        cb.Name = "cbFile";
                        cb.SetValue(Grid.RowProperty, 2);
                        cb.SetValue(Grid.ColumnProperty, 2);
                        var style = Application.Current.TryFindResource("cbxlDesign") as Style;
                        cb.VerticalContentAlignment = VerticalAlignment.Center;
                        cb.Style = style;
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
                        Grid.Children.Add(cb);
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
