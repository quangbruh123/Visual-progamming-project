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
    public class MergeSortSimulation
    {
        bool isReplaying = false;
        bool firstsort = true;
        public bool isPaused = true;
        TextBox textBox;
        Panel holder;
        public List<SubArray> subArrays = new List<SubArray>();
        List<Item> items = new List<Item>();
        List<MergeTodo> todos = new List<MergeTodo>();
        List<Item> itemsCopy;
        int row;
        float FPS = 144;//số fps của animation minh họa lại
        public MergeSortSimulation(Panel p, List<Item> refitems, TextBox t = null)
        {
            textBox = t;
            holder = p; //màn hình sort.
            items = new List<Item>(refitems); //mảng sort lấy thời gian.
            itemsCopy = CreateCopy(refitems); //bản copy sử dụng để minh họa.
            CalculateRow();
            DrawSubArray(subArrays);
            //RefreshMerge(items, 0, items.Count - 1, 1); //vẽ ra mảng trước khi sort.
            
        }
        public void CalculateRow()
        {
            row = (int)Math.Round(Math.Log2(items.Count)) + 2; // tính số hàng
            int count = (int)Math.Pow(2, row) - 1; // tính số mảng con sẽ có (số mảng con sẽ nhỏ hơn hoặc bằng count nên không bị tràn index)
            for (int i = 0; i < count; i++)
            {
                subArrays.Add(null);
            }
            subArrays[0] = new SubArray(items, 0, items.Count - 1, 1);
        }
        public int MethodSort()
        {
            if (firstsort)
            {
                SortEngine se = new MergeSort(this, ref itemsCopy, ref todos, ref subArrays, textBox);
                int kq = se.SortAsMethod();
                MessageBox.Show("Started");
                ManualReplay();
                firstsort = false;
                return kq;
            }
            else
            {
                itemsCopy = new List<Item>(CreateCopy(items));
                todos = new List<MergeTodo>();
                subArrays = new List<SubArray>();
                CalculateRow();
                SortEngine se = new MergeSort(this, ref itemsCopy, ref todos, ref subArrays, textBox);
                int kq = se.SortAsMethod();
                MessageBox.Show("Started");
                ManualReplay();
                return kq;
            }
        }
        public int SortWithResult(ref List<Item> returnItems)
        {
            if (firstsort)
            {
                SortEngine se = new MergeSort(this, ref itemsCopy, ref todos, ref subArrays, textBox);
                int kq = se.SortWithResult(ref returnItems);

                firstsort = false;
                return kq;
            }
            else
            {
                itemsCopy = new List<Item>(CreateCopy(items));
                todos = new List<MergeTodo>();
                subArrays = new List<SubArray>();
                CalculateRow();
                SortEngine se = new MergeSort(this, ref itemsCopy, ref todos, ref subArrays, textBox);
                int kq = se.SortWithResult(ref returnItems);
                return kq;
            }
        }
        public List<Item> CreateCopy(List<Item> refitems) // tạo items copy
        {
            List<Item> copy = new List<Item>();
            foreach (Item i in refitems)
            {
                Item k = new Item(i.data);
                copy.Add(k);
            }
            return copy;
        }
        
        public async void ManualReplay() // trình diễn
        {
            List<Item> localcopy = CreateCopy(items);

            //MessageBox.Show("Replaying");
            foreach (MergeTodo td in todos)
            {
                //Vsync phiên bản dbrr. Sync tần số quét màn hình sort và animation.
                //td.Execute(subArrays, itemsCopy);
                if (td.Gettype() == "Refresh")
                {
                    isPaused = true;
                    while (isPaused)
                    {
                        await Task.Delay(1);
                    }
                    td.Execute(localcopy, this);
                }
                else
                {
                    td.Execute(localcopy, this);
                }
            }
            //vẽ lại lần cuối sau khi xong.
            DrawSubArray(subArrays);
            MessageBox.Show("Đã sort xong");
        }

        public void RefreshMerge(List<Item> refitems, int start, int end, int row) // tạm bỏ trốn vì cái này chỉ vẽ ra đc 1 mảng (mảng to nhất) mà yêu cầu của tui đang là tất cả các mảng
        {
            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();

            Rect background = new Rect(0, 0, holder.Width, holder.Height);
            drawingContext.DrawRectangle(Brushes.Black, new Pen(Brushes.White, 0f), background);

            int starting = (int)(holder.Width - 50 * refitems.Count) / 2;

            for (int i = start; i <= end; i++)
            {
                Rect drawspace = new Rect(i * 50 + starting, 20 * row, 50, 25);

                refitems[i].DrawItemMergeSort(drawingContext, drawspace);
            }
            drawingContext.Close();

            DrawingBrush db = new DrawingBrush(drawingVisual.Drawing);
            holder.Background = db;
        }
        public void DrawSubArray(List<SubArray> subArrays) // cái "refresh" chính thức
        {
            // lưu ý: 1 ô: dài 40 rộng 25
            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();

            //Rect background = new Rect(0, 0, holder.Width, holder.Height);
            //drawingContext.DrawRectangle(Brushes.Black, new Pen(Brushes.White, 0f), background);

            for (int i = 0; i < subArrays.Count; i++)
            {
                if (subArrays[i] != null)
                {
                    if (i == 0) // trường hợp là mảng mẹ thì sẽ vẽ ra đặc biệt như vầy
                    {
                        int starting = (int)(holder.ActualWidth - 40 * subArrays[i].items.Count) / 2;
                        subArrays[i].firstX = starting;
                        subArrays[i].lastX = starting + subArrays[i].items.Count * 40;
                        for (int j = 0; j <= subArrays[i].items.Count - 1; j++)
                        {
                            Rect drawspace = new Rect(j * 40 + starting, 20 * 1, 40, 25);

                            subArrays[i].items[j].DrawItemMergeSort(drawingContext, drawspace);
                        }
                    }
                    else
                    {
                        switch (i % 2)
                        {
                            case 0: // nếu là mảng con bên phải thì sẽ vẽ ra như vầy
                                {
                                    int momIndex = (i - 2) / 2; // tính index của mảng mẹ của nó trong cái list
                                    int split = (int)Math.Round((subArrays[momIndex].end - subArrays[momIndex].start + 1) / (double)2); // lấy độ dài mảng mẹ chia 2 để tạo khoảng trống giữa 2 mảng con
                                    int margin = split / 2; // kết quả thụt vào cuối cùng

                                    subArrays[i].firstX = subArrays[momIndex].lastX - margin * 40 - (subArrays[i].row == row ? 5 : 0);
                                    subArrays[i].lastX = subArrays[i].firstX + (subArrays[i].end - subArrays[i].start + 1) * 40;
                                    int counting = 0;
                                    for (int j = subArrays[i].start; j <= subArrays[i].end; j++)
                                    {
                                        Rect drawspace = new Rect(counting * 40 + subArrays[i].firstX, 30 * subArrays[i].row, 40, 25);
                                        subArrays[i].items[j].DrawItemMergeSort(drawingContext, drawspace);

                                        counting++;
                                    }

                                    break;
                                }
                            case 1: // trường hợp mảng con bên trái
                                {
                                    int momIndex = (i - 1) / 2;
                                    int split = (int)Math.Round((subArrays[momIndex].end - subArrays[momIndex].start + 1) / (double)2);
                                    int margin = split / 2;

                                    subArrays[i].lastX = subArrays[momIndex].firstX + margin * 40 + (subArrays[i].row == row ? 5 : 0);
                                    subArrays[i].firstX = subArrays[i].lastX - (subArrays[i].end - subArrays[i].start + 1) * 40;
                                    int counting = 0;
                                    for (int j = subArrays[i].start; j <= subArrays[i].end; j++)
                                    {
                                        Rect drawspace = new Rect(counting * 40 + subArrays[i].firstX, 30 * subArrays[i].row, 40, 25);
                                        subArrays[i].items[j].DrawItemMergeSort(drawingContext, drawspace);

                                        counting++;
                                    }
                                    break;
                                }
                        }
                    }
                }
            }
            drawingContext.Close();

            DrawingBrush db = new DrawingBrush(drawingVisual.Drawing);
            holder.Background = db;
        }

        public void Pause()
        {
            isPaused = !isPaused;
        }

        public void Stop()
        {
            if (isReplaying)
            {
                isReplaying = false;
                isPaused = true;
            }
        }

        public void Initialize()
        {
            DrawSubArray(subArrays);
        }
    }
    // 2 * i + 1 (sub array trái)
    // 2 * i + 2 (sub array phải)
    public class SubArray
    {
        public int start, end;
        public int firstX, lastX;
        public int row;
        public List<Item> items = null;

        public SubArray(List<Item> a, int s, int e, int r)
        {
            items = new List<Item>();
            for (int i = 0; i < a.Count; i++)
            {
                items.Add(new Item(a[i]));
            }    
            start = s;
            end = e;
            row = r;
        }

        // cần 1 class subarray để lưu cái tọa độ bắt đầu của nó, tọa độ kết thúc, index bắt đầu của nó, index kết thúc, dòng của nó trong cái trực quan
        // cần 1 list như vậy để lưu lại toàn bộ sub array cho nó để tiện cho vẽ hơn.
        // 1 list như vậy sẽ lưu theo cái cấu trúc cây (na ná heap sort)
        // mảng con bên trái sẽ là 2*i+1, phải là 2*i+2
    }

    //dùng để lưu lại cái câu lệnh liên quan đến xuất ra màn hình sort, dùng riêng cho merge sort.
    public class MergeTodo
    {
        string type;
        int arrange, row, start, end;
        List<Item> items1 = null;
        TextBox textBox;

        public MergeTodo(string reftype, int start, int end, int arrange, int row)
        {
            type = reftype;
            this.arrange = arrange;
            this.row = row;
            this.start = start;
            this.end = end;
        }
        
        public MergeTodo(string reftype)
        {
            type = reftype;
        }

        public MergeTodo(string reftype, TextBox t)
        {
            type = reftype;
            textBox = t;
        }

        public MergeTodo(string reftype, int arrange)
        {
            type = reftype;
            this.arrange = arrange;
        }

        public MergeTodo(string reftype, int arrange, List<Item> i) // update
        {
            type = reftype;
            this.arrange = arrange;
            items1 = new List<Item>(i);
        }
        public void Execute(List<Item> items, MergeSortSimulation ms)
        {
            switch (type)
            {
                case "Refresh":
                    {
                        ms.DrawSubArray(ms.subArrays);
                        break;
                    }
                case "AddSubArray":
                    {
                        ms.subArrays[arrange] = new SubArray(items, start, end, row);
                        break;
                    }
                case "DeleteSubArray":
                    {
                        ms.subArrays[arrange] = null;
                        break;
                    }
                case "Update":
                    {
                        ms.subArrays[arrange].items = new List<Item>(items1);
                        break;
                    }
                case "SelectL":
                    {
                        textBox.Text = "Chọn nửa mảng bên trái.";
                        break;
                    }
                case "SelectR":
                    {
                        textBox.Text = "Chọn nửa mảng bên phải";
                        break;
                    }
                case "Ready":
                    {
                        textBox.Text = "Mảng chỉ còn chứa 1 phần tử không thể chia được nữa, chuẩn bị merge.";
                        break;
                    }
                case "Split":
                    {
                        textBox.Text = "Chia mảng ra làm 2 nửa.";
                        break;
                    }
                case "Merge":
                    {
                        textBox.Text = "Merge 2 mảng con lại, theo thứ tự tăng dần";
                        break;
                    }
                case "MergeInfo":
                    {
                        textBox.Text = "Đây là merge sort";
                        break;
                    }
                case "ChangeColor":
                    {
                        for (int i = start; i <= end; i++)
                        {
                            ms.subArrays[arrange].items[i].changeColor(Colors.Green);// = Colors.Green;
                        }
                        ms.DrawSubArray(ms.subArrays);
                        break;
                    }
                case "ResetColor":
                    {
                        for (int i = 0; i < ms.subArrays[0].items.Count; i++)
                        {
                            ms.subArrays[0].items[i].ResetColor();
                        }
                        ms.DrawSubArray(ms.subArrays);
                        break;
                    }
            }
        }

        public string Gettype()
        {
            return type;
        }
    }
}
