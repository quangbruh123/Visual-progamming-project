using System;
using System.Collections;
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
using System.Threading;
using System.Diagnostics;

namespace Da_projekt
{
    public class SortSimulation
    {
        Stopwatch a = new Stopwatch();

        SortEngine se;
        Panel holder;
        public List<Item> items = new List<Item>();
        List<Item> itemsCopy;
        public List<Todo> todos = new List<Todo>();
        Thread thread;

        float FPS = 144f;//số fps của animation minh họa lại

        public SortSimulation(Panel p, List<Item> refitems)
        {
            holder = p; //màn hình sort.
            items = new List<Item>(refitems); //mảng sort lấy thời gian.
            itemsCopy = CreateCopy(refitems); //bản copy sử dụng để minh họa.
            refresh(items); //vẽ ra mảng trước khi sort.
        }

        //trả về thời gian sort theo mili-giây. mảng 1000 phần tử sort hết 282ms.
        public int startSort()
        {
            //không sử dụng thread vì -lag -thread.sleep làm sai thời gian sort ghi được.
            SortEngine se = new SelectionSort(this);
            int kq = se.Sort();
            MessageBox.Show("Đã sort xong sau: " + kq.ToString() + "ms.");
            startReplicate(); //bắt đầu minh họa lại quá trình sort.
            return kq;
        }

        //minh họa lại quá trình sort.
        public async void startReplicate()
        {
            foreach (Todo td in todos)
            {
                //Vsync phiên bản dbrr. Sync tần số quét màn hình sort và animation.
                if (td.Gettype() == "Refresh")
                {
                    a.Stop();
                    if (a.ElapsedMilliseconds < (1000f / FPS))
                    {
                        await Task.Delay(((int)(1000f / FPS - a.ElapsedMilliseconds)));//đợi đến lần quét màn hình tiếp theo
                    }
                    a.Restart();
                    td.Execute(itemsCopy);
                }
                else
                    td.Execute(itemsCopy);
            }
            //vẽ lại lần cuối sau khi xong.
            LearnSortPanel.instance.refresh(itemsCopy);
        }

        public List<Item> CreateCopy(List<Item> refitems)
        {
            List<Item>  copy = new List<Item>();
            foreach (Item i in refitems)
            {
                Item k = new Item(i.data);
                copy.Add(k);
            }
            return copy;
        }

        public void ResetColors()
        {
            foreach (Item i in items)
            {
                i.ResetColor();
            }
        }

        public void refresh(List<Item> refitems)
        {
            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();

            Rect background = new Rect(new Point(0, 0), new Point(holder.Width, holder.Height));
            drawingContext.DrawRectangle(Brushes.Black, new Pen(Brushes.White, 0f), background);

            float spacing = ((float)holder.Width) / ((float)(refitems.Count));

            for (int i = 0; i < refitems.Count; i++)
            {
                Rect column = new Rect(new Point(spacing * i, holder.Height - refitems[i].data - 1), new Point(spacing * (i + 1), holder.Height));
                drawingContext.DrawRectangle(refitems[i].brush(), new Pen(Brushes.Black, 0.5f), column);
            }
            drawingContext.Close();

            DrawingBrush db = new DrawingBrush(drawingVisual.Drawing);
            holder.Background = db;
        }

        [Obsolete]
        private void Test()
        {
            DrawingVisual drawingVisual = new DrawingVisual();

            DrawingContext drawingContext = drawingVisual.RenderOpen();

            Rect background = new Rect(new Point(0, 0), new Point(holder.Width, holder.Height));

            drawingContext.DrawRectangle(Brushes.White, new Pen(Brushes.White, 1f), background);

            drawingContext.DrawText(new FormattedText("Test", System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight, new Typeface("Times New Roman"), 25, Brushes.Black), new System.Windows.Point(0, 0));

            drawingContext.Close();

            DrawingBrush db = new DrawingBrush(drawingVisual.Drawing);
            holder.Background = db;
        }
    }

    //dùng để lưu lại cái câu lệnh liên quan đến xuất ra màn hình sort.
    public class Todo
    {
        string type;
        int item1 = 0;
        int item2 = 0;
        Color color = Colors.White;

        public Todo(string reftype)
        {
            type = reftype;
        }

        public Todo(string reftype, int refitemindex)
        {
            type = reftype;
            item1 = refitemindex;
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
                    int Backup = items[item1].data;
                    items[item1].data = items[item2].data;
                    items[item2].data = Backup;
                    break;
            }
        }

        public string Gettype()
        {
            return type;
        }
    }
}
