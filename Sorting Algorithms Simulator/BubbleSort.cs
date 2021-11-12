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
        public BubbleSort()
        {
            form = SortProject.instance;
        }

        public void Sort()
        {
            /*
            for (int i = 0; i < form.n; i++)
            {
                for (int j = 0; j < form.n - i - 1; j++)
                {
                    form.array[j].BackColor = Color.Red;
                    form.array[j].ForeColor = Color.White;

                    form.array[j + 1].BackColor = Color.Red;
                    form.array[j + 1].ForeColor = Color.White;

                    form.lbi.Location = new Point(i * 60, 100);
                    form.lbj.Location = new Point(j * 60, 80);
                    form.lbj1.Location = new Point((j + 1) * 60, 80);
                    Thread.Sleep(form.speed * 100);
                    if (int.Parse(form.array[j].Text) * form.sortOrder > int.Parse(form.array[j + 1].Text) * form.sortOrder)
                    {
                        SwitchLabel(ref form.array[j], ref form.array[j + 1]);
                    }
                    form.array[j].BackColor = Color.Yellow;
                    form.array[j].ForeColor = Color.Black;
                    form.array[j + 1].BackColor = Color.Yellow;
                    form.array[j + 1].ForeColor = Color.Black;
                }
            }
            MessageBox.Show("Đã sắp xếp xong!", "Thông báo!");
            */
        }
    }
}

