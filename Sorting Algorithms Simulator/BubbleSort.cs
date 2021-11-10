using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace Sorting_Algorithms_Simulator
{
    class BubbleSort : SortEngine
    {
        SortProject form;
        Visualizer vslz;
        
        public BubbleSort()
        {
            form = SortProject.instance;
            vslz = form.vslz;
        }

        public void Sort()
        {
            vslz.Reset();

            Font f = new Font(FontFamily.GenericSansSerif, 20f, FontStyle.Regular, GraphicsUnit.Pixel);
            vslz.WriteString("Màu đỏ: i đang xét.\nMàu lam: j đang xét.\nMàu lục: Đã sắp xếp xong", f, Color.Black, new Point(0, 100));

            for (int i = 0; i < form.list.Count; i++)
            {  
                for (int j = 0; j < form.list.Count - i - 1; j++)
                {
                    vslz.ChangeColor(form.list[j], Color.Red);
                    vslz.ChangeColor(form.list[j + 1], Color.LightBlue);
                    vslz.DrawAllItems();
                    Thread.Sleep(form.speed());

                    if (form.list[j].data * form.sortOrder > form.list[j + 1].data * form.sortOrder)
                    {
                        int temp = form.list[j + 1].data;
                        form.list[j + 1].data = form.list[j].data;
                        form.list[j].data = temp;

                        vslz.ResetColor(form.list[j]);
                        vslz.ResetColor(form.list[j + 1]);
                    }
                    
                    vslz.ResetColor(form.list[j]);
                    vslz.ResetColor(form.list[j + 1]);

                }
                vslz.ChangeColor(form.list[form.list.Count - i - 1], Color.Green);
            }

            for (int i = 0; i < form.list.Count; i++)
            {
                vslz.ResetColor(form.list[i]);
            }

            vslz.Reset();
            vslz.DrawAllItems();
            MessageBox.Show("Đã sắp xếp xong!", "Thông báo!");
        }
    }
}

