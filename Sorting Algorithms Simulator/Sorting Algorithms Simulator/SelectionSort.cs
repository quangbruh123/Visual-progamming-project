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

        public SelectionSort()
        {
            form = SortProject.instance;
        }

        public void Sort()
        {

            // Selection Sort
            for (int i = 0; i < form.n - 1; i++)
            {
                // heightlight phần tử i lên
                form.array[i].BackColor = Color.Red;
                form.array[i].ForeColor = Color.White;

                int min = i;
                form.lbi.Location = new Point(i * 60, form.lbi.Location.Y);
                form.lbmin.Location = new Point(i * 60, form.lbmin.Location.Y);

                Thread.Sleep(form.speed * 100);
                for (int j = i + 1; j < form.n; j++)
                {
                    form.array[j].BackColor = Color.Blue;
                    form.array[j].ForeColor = Color.White;

                    form.lbj.Location = new Point(j * 60, form.lbj.Location.Y);
                    Thread.Sleep(form.speed * 100);
                    if (int.Parse(form.array[min].Text) * form.typeofSort > int.Parse(form.array[j].Text) * form.typeofSort)
                    {
                        min = j;
                        form.array[min].BackColor = Color.Red;
                        form.array[min].ForeColor = Color.White;

                        form.lbmin.Location = new Point(min * 60, form.lbmin.Location.Y);
                    }
                    else
                    {
                        form.array[j].BackColor = Color.Yellow;
                        form.array[j].ForeColor = Color.Black;
                    }

                    Thread.Sleep(form.speed * 100);

                }
                if (i != min)
                {
                    SwitchLabel(ref form.array[i], ref form.array[min]);
                    form.array[i].BackColor = Color.Red;
                    form.array[i].ForeColor = Color.White;
                    form.array[min].BackColor = Color.Red;
                    form.array[min].ForeColor = Color.White;
                    Thread.Sleep(form.speed * 100);
                }
                form.array[i].BackColor = Color.Yellow;
                form.array[i].ForeColor = Color.Black;
                form.array[min].BackColor = Color.Yellow;
                form.array[min].ForeColor = Color.Black;
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

