using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Da_projekt
{
    //dùng để lưu lại cái câu lệnh liên quan đến xuất ra màn hình sort.
    public class Todo
    {
        string type;
        int item1 = 0;
        int item2 = 0;
        Color color = Colors.White;
        TextBox textBox;

        public Todo(string reftype)
        {
            type = reftype;
        }
        
        public Todo(string reftype, TextBox t)
        {
            type = reftype;
            textBox = t;
        }

        public Todo(string reftype, int refitemindex)
        {
            type = reftype;
            item1 = refitemindex;
        }

        public Todo(string reftype, int refitemindex, TextBox t)
        {
            type = reftype;
            item1 = refitemindex;
            textBox = t;
        }

        public Todo(string reftype, int refitemindex, Color refcolor)
        {
            type = reftype;
            item1 = refitemindex;
            color = refcolor;
        }

        public Todo(string reftype, int refitemindex1, int refitemindex2)
        {
            type = reftype;
            item1 = refitemindex1;
            item2 = refitemindex2;
        }
        public Todo(string reftype, int refitemindex1, int refitemindex2, TextBox t)
        {
            type = reftype;
            item1 = refitemindex1;
            item2 = refitemindex2;
            textBox = t;
        }

        public void Execute(List<Item> items)
        {
            switch (type)
            {
                case "Refresh":
                    LearnSortPanel.instance.refresh(items);
                    break;
                case "ResetColor":
                    items[item1].ResetColor();
                    break;
                case "ChangeColor":
                    items[item1].changeColor(color);
                    break;
                case "Switch":
                    textBox.Text = "Swap";
                    int Backup = items[item1].data;
                    items[item1].data = items[item2].data;
                    items[item2].data = Backup;
                    break;
                case "IntroBB":
                    textBox.Text = "Đây là BB sort.";
                    break;
                case "Starting":
                    textBox.Text = "Xét vị trí thứ " + item1;
                    break;
                case "CompareBB":
                    textBox.Text = $"Xét cặp thứ {item1} - {item2}";
                    break;
                case "DoneBB":
                    textBox.Text = $"Đã xong, bây giờ vị trí cuối cùng được xử lý là phần tử lớn nhất";
                    break;
            }
        }

        public string Gettype()
        {
            return type;
        }
    }
}
