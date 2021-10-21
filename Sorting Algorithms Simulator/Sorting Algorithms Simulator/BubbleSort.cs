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
                    if (int.Parse(form.array[j].Text) * form.typeofSort > int.Parse(form.array[j + 1].Text) * form.typeofSort)
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
        }

        void SwitchLabel(ref Label a, ref Label b)
        {
            int x1 = a.Location.X;
            int x2 = b.Location.X;
            int y = a.Location.Y;

            if (a.Location.X < b.Location.X)
            {
                while (a.Location.Y > y - 40)
                {
                    Thread.Sleep(form.speed);

                    a.Location = new Point(a.Location.X, a.Location.Y - 1);
                    b.Location = new Point(b.Location.X, b.Location.Y - 1);
                }
                while (a.Location.X < x2 && b.Location.X > x1)
                {
                    Thread.Sleep(form.speed);

                    a.Location = new Point(a.Location.X + 1, a.Location.Y);
                    b.Location = new Point(b.Location.X - 1, b.Location.Y);
                }
                while (a.Location.Y < y)
                {
                    Thread.Sleep(form.speed);

                    a.Location = new Point(a.Location.X, a.Location.Y + 1);
                    b.Location = new Point(b.Location.X, b.Location.Y + 1);
                }
            }

            Label tmp = a;
            a = b;
            b = tmp;
        }
    }
}

