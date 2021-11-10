using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
namespace Sorting_Algorithms_Simulator
{
    class QuickSort : SortEngine
    {

        SortProject form;
        Visualizer vslz;

        public QuickSort()
        {
            form = SortProject.instance;
            vslz = form.vslz;
        }

        public void Sort()
        {
            vslz.Reset();

            Font f = new Font(FontFamily.GenericSansSerif, 20f, FontStyle.Regular, GraphicsUnit.Pixel);
            vslz.WriteString("Màu đỏ: i đang xét.\nMàu lục: j đang xét.\nMàu lam: chosen đang xét.\nMàu cam: 2 phần tử đổi cho nhau", f, Color.Black, new Point(0, 100));
            QuickSortWork(form.list, 0, form.list.Count - 1);
            vslz.Reset();
            vslz.DrawAllItems();
            MessageBox.Show("Đã sắp xếp xong!", "Thông báo!");
        }
        public void QuickSortWork(List<Item> a, int leftModule, int rightModule)
        {
            int i, j, mid, chosen;
            mid = (leftModule + rightModule) / 2;
            chosen = a[mid].data;
            i = leftModule;
            j = rightModule;
            vslz.ChangeColor(a[j], Color.Green);
            vslz.ChangeColor(a[i], Color.Red);
            vslz.ChangeColor(a[mid], Color.Blue);
            vslz.DrawAllItems();
            Thread.Sleep(form.speed());
            while (i <= j)
            {
                vslz.DrawAllItems();
                while ((a[i].data * form.sortOrder < chosen * form.sortOrder) && (i<=j))
                {
                    vslz.ResetColor(a[i]);
                    i++;
                    vslz.ChangeColor(a[i], Color.Red);
                    vslz.DrawAllItems();
                    Thread.Sleep(form.speed());
                }
                while ((a[j].data * form.sortOrder > chosen * form.sortOrder) && (j>=i))
                {
                    vslz.ResetColor(a[j]);
                    j--;
                    vslz.ChangeColor(a[j], Color.Green);
                    vslz.DrawAllItems();
                    Thread.Sleep(form.speed());
                }
                if (i <= j)
                {
                    if (i < j)
                    {
                        int Temp = a[i].data;
                        a[i].data = a[j].data;
                        a[j].data = Temp;
                        vslz.ChangeColor(a[i], Color.Orange);
                        vslz.ChangeColor(a[j], Color.Orange);
                        vslz.DrawAllItems();
                        Thread.Sleep(form.speed());
                    }
                    vslz.ResetColor(a[i]);
                    vslz.ResetColor(a[j]);
                    i++;
                    j--;
                    if (i <= rightModule)
                    {
                        vslz.ChangeColor(a[i], Color.Red);
                    }
                    if (j >= leftModule)
                    {
                        vslz.ChangeColor(a[j], Color.Green);
                    }
                }
                vslz.DrawAllItems();
                Thread.Sleep(form.speed());
            }
            if (i <= rightModule)
                vslz.ResetColor(a[i]);
            if (j >= leftModule)
                vslz.ResetColor(a[j]);
            vslz.DrawAllItems();
            Thread.Sleep(form.speed());
            if (leftModule < j)
                QuickSortWork(a, leftModule, j);
            if (i < rightModule)
                QuickSortWork(a, i, rightModule);
        }
    }
}
