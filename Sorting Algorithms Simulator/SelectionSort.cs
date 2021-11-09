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
    class SelectionSort : SortEngine
    {
        
        SortProject form;
        Visualizer vslz;

        public SelectionSort()
        {
            form = SortProject.instance;
            vslz = form.vslz;
        }
        
        public void Sort()
        {
            vslz.Reset();

            Font f = new Font(FontFamily.GenericSansSerif, 20f, FontStyle.Regular, GraphicsUnit.Pixel);
            vslz.WriteString("Màu đỏ: i đang xét.\nMàu lục: j đang xét.\nMàu lam: min.", f, Color.Black, new Point(0, 100));

            // Selection Sort
            for (int i = 0; i < form.list.Count; i++)
            {
                int min = i;
                vslz.ChangeColor(form.list[min], Color.Blue);

                vslz.ChangeColor(form.list[i], Color.Red);

                vslz.DrawAllItems();

                Thread.Sleep(form.speed());
                for (int j = i + 1; j < form.list.Count; j++)
                {
                    vslz.ChangeColor(form.list[j], Color.Green);
                    vslz.DrawAllItems();

                    if (form.list[min].data * form.sortOrder > form.list[j].data * form.sortOrder)
                    {
                        if (min != i)
                            vslz.ResetColor(form.list[min]);

                        min = j;

                        vslz.ChangeColor(form.list[min], Color.Blue);
                    }
                    else
                    {
                    }

                    Thread.Sleep(form.speed());
                    if (min != j)
                        vslz.ResetColor(form.list[j]);
                }
                if (i != min)
                {
                    int Backup = form.list[i].data;
                    form.list[i].data = form.list[min].data;
                    form.list[min].data = Backup;
                    Thread.Sleep(form.speed());

                    vslz.ResetColor(form.list[min]);
                }

                vslz.ResetColor(form.list[i]);
            }

            vslz.Reset();
            vslz.DrawAllItems();
            MessageBox.Show("Đã sắp xếp xong!", "Thông báo!");
        }
    }
}
