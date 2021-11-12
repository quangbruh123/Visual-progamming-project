using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;


namespace Sorting_Algorithms_Simulator
{
    class InsertionSort : SortEngine
    {
        SortProject form;
        Visualizer vslz;
        public InsertionSort()
        {
            form = SortProject.instance;
            vslz = form.vslz;
        }

        public void Sort()
        {
            vslz.Reset();
            vslz.DrawAllItems();
            Font f = new Font(FontFamily.GenericSansSerif, 20f, FontStyle.Regular, GraphicsUnit.Pixel);
            vslz.WriteString("Màu đỏ: i đang xét.\nMàu lục: j đang xét", f, Color.Black, new Point(0, 100));
            int i, key, j;

            for (i = 1; i < form.list.Count; i++)
            {
                key = form.list[i].data;
                vslz.ChangeColor(form.list[i], Color.Red);
                vslz.DrawAllItems();
                Thread.Sleep(form.speed());
                j = i - 1;

                while (j >= 0 && form.list[j].data * form.sortOrder > key*form.sortOrder)
                {

                    form.list[j+1].data = form.list[j].data;
                    vslz.ChangeColor(form.list[j], Color.Green);
                    vslz.DrawAllItems();
                    Thread.Sleep(form.speed());
                    vslz.ResetColor(form.list[j]);
                    j = j - 1;
                }
                form.list[j+1].data = key;
                vslz.ResetColor(form.list[i]);
                Thread.Sleep(form.speed());
            }
            vslz.Reset();
            vslz.DrawAllItems();
            MessageBox.Show("Đã sắp xếp xong!", "Thông báo!");
        }
    }
}
