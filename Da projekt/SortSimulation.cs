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
        public bool isPausing = true;
        public bool isReplaying = false;
        bool firstsort = true;

        SortEngine se;
        Panel holder;
        TextBox textBox;

        List<Item> items = new List<Item>();
        List<Todo> todos = new List<Todo>();
            List<Item> itemsCopy;
        
        Thread thread;
        Thread thread1;

        float FPS = 144;//số fps của animation minh họa lại

        public SortSimulation(Panel p, List<Item> refitems, TextBox t)
        {
            holder = p; //màn hình sort.
            textBox = t; // text box
            items = new List<Item>(refitems); //mảng sort lấy thời gian.
            itemsCopy = CreateCopy(refitems); //bản copy sử dụng để minh họa.
            refresh(items); //vẽ ra mảng trước khi sort.
        }

        public SortSimulation(Panel p, List<Item> refitems, List<Todo> reftodo)
        {
            holder = p; //màn hình sort.
            todos = reftodo;
            items = new List<Item>(refitems); //mảng sort lấy thời gian.
            itemsCopy = CreateCopy(refitems); //bản copy sử dụng để minh họa.
            refresh(items); //vẽ ra mảng trước khi sort.
        }

        //trả về thời gian sort theo mili-giây. mảng 1000 phần tử sort hết 282ms.
        public void ThreadSort()
        {
            if (firstsort)
            {
                //không sử dụng thread vì -lag -thread.sleep làm sai thời gian sort ghi được.
                SortEngine se = new QuickSort(this, items, ref todos, textBox);
                thread = new Thread(se.SortAsThread);
                thread.IsBackground = true;
                thread.Start();

                thread1 = new Thread(waitForThreadsort);
                thread1.IsBackground = true;
                thread1.Start();
                firstsort = false;
            } else
            {
                SortEngine se = new QuickSort(this, CreateCopy(itemsCopy), ref todos, textBox);
                thread = new Thread(se.SortAsThread);
                thread.IsBackground = true;
                thread.Start();

                thread1 = new Thread(waitForThreadsort);
                thread1.IsBackground = true;
                thread1.Start();
            }
        }

        public int MethodSort()
        {
            if (firstsort)
            {
                SortEngine se = new QuickSort(this, items, ref todos, textBox);
                int kq = se.SortAsMethod();
                MessageBox.Show(kq.ToString());
                firstsort = false;
                return kq;
            } else
            {
                todos = new List<Todo>();
                SortEngine se = new QuickSort(this, CreateCopy(itemsCopy), ref todos, textBox);
                int kq = se.SortAsMethod();
                MessageBox.Show(kq.ToString());
                return kq;
            }
        }

        private void waitForThreadsort()
        {
            thread.Join();
            MessageBox.Show("Đã sort xong");
        }

        //minh họa lại quá trình sort.
        public async void Replay()
        {
            List<Item> localcopy = CreateCopy(itemsCopy);

            Stopwatch a = new Stopwatch();
            //MessageBox.Show("Replaying");
            a.Start();
            foreach (Todo td in todos)
            {
                //Vsync phiên bản dbrr. Sync tần số quét màn hình sort và animation.
                if (td.Gettype() == "Refresh")
                {
                    td.Execute(localcopy);
                    a.Stop();
                    if (a.ElapsedMilliseconds < (1000f / FPS))
                    {
                        await Task.Delay(((int)(1000f / FPS - a.ElapsedMilliseconds)));
                        //đợi đến lần quét màn hình tiếp theo
                    }
                    a.Restart();
                }
                else
                    td.Execute(localcopy);
            }
            //vẽ lại lần cuối sau khi xong.
            LearnSortPanel.instance.refresh(localcopy);
            //MessageBox.Show("Đã sort xong");
        }

        public async void Replay(List<Todo> reftodo)
        {
            List<Item> localcopy = CreateCopy(itemsCopy);
            Stopwatch a = new Stopwatch();
            //MessageBox.Show("Replaying");
            foreach (Todo td in reftodo)
            {
                //Vsync phiên bản dbrr. Sync tần số quét màn hình sort và animation.
                if (td.Gettype() == "Refresh")
                {
                    a.Stop();
                    if (a.ElapsedMilliseconds < (1000f / FPS))
                    {
                        await Task.Delay(((int)(1000f / FPS - a.ElapsedMilliseconds)));
                        //đợi đến lần quét màn hình tiếp theo
                    }
                    a.Restart();
                }
                else
                    td.Execute(localcopy);
            }
            //vẽ lại lần cuối sau khi xong.
            LearnSortPanel.instance.refresh(localcopy);
            //MessageBox.Show("Đã sort xong");
        }

        public async void ManualReplay()
        {
            List<Item> localcopy = CreateCopy(itemsCopy);

            //MessageBox.Show("Replaying");
            foreach (Todo td in todos)
            {
                //Vsync phiên bản dbrr. Sync tần số quét màn hình sort và animation.
                if (td.Gettype() == "Refresh")
                {
                    td.Execute(localcopy);
                    isPausing = true;
                    while (isPausing)
                    {
                        await Task.Delay((int)(1000f / FPS));
                    }
                }
                else
                    td.Execute(localcopy);
            }
            //vẽ lại lần cuối sau khi xong.
            LearnSortPanel.instance.refresh(localcopy);
            MessageBox.Show("Đã sort xong");
        }

        public async void FancyReplay()
        {
            List<Item> localcopy = CreateCopy(itemsCopy);

            MessageBox.Show("Replaying");
            List<Todo> a = new List<Todo>();
            List<Todo> b = new List<Todo>();

            foreach (Todo td in todos)
            {
                //Vsync phiên bản dbrr. Sync tần số quét màn hình sort và animation.
                if (td.Gettype() == "FancyPause")
                {
                    isPausing = true;
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    while (isPausing)
                    {
                        localcopy = CreateCopy(itemsCopy);
                        foreach (Todo tda in a)
                        {
                            if (td.Gettype() != "Refresh")
                                tda.Execute(localcopy);
                        }
                        foreach (Todo tdb in b)
                        {
                            //await Task.Delay(100);
                            


                            if (tdb.Gettype() == "Switch")
                            {
                                sw.Stop();
                                LearnSortPanel.instance.refresh(localcopy);
                                await Task.Delay(1000);
                                tdb.Execute(localcopy);
                                LearnSortPanel.instance.refresh(localcopy);
                                await Task.Delay(1000);
                                sw.Restart();
                            } else if (tdb.Gettype() != "ResetColor")
                            {
                                tdb.Execute(localcopy);
                                sw.Stop();
                                if (sw.ElapsedMilliseconds < (1000f / FPS))
                                {
                                    LearnSortPanel.instance.refresh(localcopy);
                                    await Task.Delay(((int)(1000f / FPS - sw.ElapsedMilliseconds)));
                                }
                                sw.Restart();
                            } else
                            {
                                tdb.Execute(localcopy);
                            }
                        }
                    }
                    b.Clear();
                }
                else
                {
                    a.Add(td);
                    b.Add(td);
                }
            }
            //vẽ lại lần cuối sau khi xong.
            LearnSortPanel.instance.refresh(itemsCopy);
            MessageBox.Show("Đã sort xong");
        }

        private void ResetAllColors(List<Item> refitems)
        {
            foreach (Item i in refitems)
            {
                i.ResetColor();
            }
        }

        public void pause()
        {
            if (thread.IsAlive)
            {
                Thread.Sleep(Timeout.Infinite);
                isPausing = true;
            }
        }

        public void resume()
        {
            if (thread.IsAlive)
            {
                thread.Interrupt();
                isPausing = false;
            }
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

        public void refresh(List<Item> refitems)
        {
            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();

            Rect background = new Rect(new Point(0, 0), new Point(holder.Width, holder.Height));
            drawingContext.DrawRectangle(Brushes.Black, new Pen(Brushes.White, 0f), background);

            float spacing = ((float)holder.Width) / ((float)(refitems.Count));

            for (int i = 0; i < refitems.Count; i++)
            {
                Rect drawspace = new Rect(new Point(spacing * i, holder.Height - refitems[i].data - 1), new Point(spacing * (i + 1), holder.Height));

                refitems[i].drawItemSelectionSort(drawingContext, drawspace);
            }
            drawingContext.Close();

            DrawingBrush db = new DrawingBrush(drawingVisual.Drawing);
            holder.Background = db;
        }

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

    
}
