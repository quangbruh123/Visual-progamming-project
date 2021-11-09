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
    class InterchangeSort : SortEngine
    {
        SortProject form;
        Visualizer vslz;

        public InterchangeSort()
        {
            form = SortProject.instance;
            vslz = form.vslz;
        }

        public void Sort()
        {
            vslz.Reset();

            Font f = new Font(FontFamily.GenericSansSerif, 20f, FontStyle.Regular, GraphicsUnit.Pixel);
            vslz.WriteString("Màu đỏ: i đang xét.\nMàu lục: j đang xét.", f, Color.Black, new Point(0, 100));

            for (int i = 0; i < form.list.Count; i++)
            {
                vslz.ChangeColor(form.list[i], Color.Red);
                vslz.DrawAllItems();
                Thread.Sleep(form.speed());

                for (int j = i + 1; j < form.list.Count; j++)
                {
                    vslz.ChangeColor(form.list[j], Color.Green);

                    vslz.DrawAllItems();

                    Thread.Sleep(form.speed());
                    if (form.list[i].data * form.sortOrder > form.list[j].data * form.sortOrder)
                    {
                        int temp = form.list[j].data;
                        form.list[j].data = form.list[i].data;
                        form.list[i].data = temp;

                        vslz.ResetColor(form.list[j]);
                        vslz.DrawAllItems();
                    }

                    vslz.ResetColor(form.list[j]);
                }
                vslz.ResetColor(form.list[i]);
                vslz.DrawAllItems();
                Thread.Sleep(form.speed());
            }

            vslz.Reset();
            vslz.DrawAllItems();
            MessageBox.Show("Đã sắp xếp xong!", "Thông báo!");
        }

    }
}
