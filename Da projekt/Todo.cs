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
        int item3 = 0;
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

        public Todo(string reftype, int refitemindex1, int refitemindex2, int refitemindex3, TextBox t)
        {
            type = reftype;
            item1 = refitemindex1;
            item2 = refitemindex2;
            item3 = refitemindex3;
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
                case "IntroInsert":
                    textBox.Text = "Đây là Insertion sort.";
                    break;
                case "IntroInterchange":
                    textBox.Text = "Đây là Interchange sort.";
                    break;
                case "IntroSS":
                    textBox.Text = "Đây là Selection Sort";
                    break;
                case "IntroQS":
                    textBox.Text = "Đây là Quick Sort";
                    break;
                case "DescriptQS":
                    textBox.Text = $"Xét pivot là phần tử thứ {item1} (màu vàng), phần tử bắt đầu của mảng bên trái là phần tử thứ {item2}, phần tử bắt đầu của mảng bên trái là phần tử thứ {item3}.";
                    break;
                case "Starting":
                    textBox.Text = "Xét phần tử thứ " + item1;
                    break;
                case "StartingSub":
                    textBox.Text = "Xét phần tử phụ thứ " + item1;
                    break;
                case "StartingLeft":
                    textBox.Text = "Xét mảng bên trái, phần tử thứ " + item1;
                    break;
                case "StartingRight":
                    textBox.Text = "Xét mảng bên phải, phần tử thứ " + item1;
                    break;
                case "DiffQS":
                    textBox.Text = "Xét các phần tử tiếp theo của 2 mảng";
                    break;
                case "CompareBB":
                    textBox.Text = $"Xét cặp thứ {item1} - {item2}";
                    break;
                case "DoneBB":
                    textBox.Text = $"Đã xong, bây giờ vị trí cuối cùng được xử lý là phần tử lớn nhất";
                    break;
                case "DoneIC":
                    textBox.Text = $"Đã xong vòng lặp của phần tử thứ {item1}, bây giờ xét phần tử tiếp theo.";
                    break;
                case "AnnounceInsert":
                    textBox.Text = $"Phần tử thứ {item1} cũ đã chèn tới vị trí mới là vị trí thứ {item2}";
                    break;
                case "NoChangeInsert":
                    textBox.Text = "Xét qua mọi phần tử ở bên trái phần tử được xét, nhận thấy không có phần tử nào lớn hơn phần tử này cả. Qua đó xét phần tử tiếp theo.";
                    break;
                case "ConfirmMin":
                    textBox.Text = $"Nhận thấy phần tử thứ {item1} bé hơn phần tử chính đang xét, gán cho min = phần tử này";
                    break;
                case "Done":
                    textBox.Text = "Dãy số đã được xếp xong!";
                    break;
            }
        }

        public string Gettype()
        {
            return type;
        }
    }
}
