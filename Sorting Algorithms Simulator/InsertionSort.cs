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
        public InsertionSort()
        {
            form = SortProject.instance;
        }

        public void Sort()
        {
            /*
            for (int i = 1; i < form.n; i++)
            {
                form.array[i].ForeColor = Color.White;
                form.array[i].BackColor = Color.Red;

                Label key = form.array[i];
                int j = i - 1;

                // vẽ i j với (j-1)
                form.lbi.Location = new Point(i * 60, 100);
                form.lbj.Location = new Point(j * 60, 80);
                form.lbj1.Location = new Point((j - 1) * 60, 80);
                while (key.Location.Y > 20)
                {
                    key.Location = new Point(key.Location.X, key.Location.Y - 1);
                    Thread.Sleep(form.speed);
                }


                while (j >= 0 && int.Parse(form.array[j].Text) * form.sortOrder > int.Parse(key.Text) * form.sortOrder)
                {
                    //arr[j + 1] = arr[j];
                    //j = j - 1;

                    while (form.array[j].Location.X != form.LocationOfLabels[j + 1].X)
                    {
                        form.array[j].Location = new Point(form.array[j].Location.X + 1, form.array[j].Location.Y);
                        Thread.Sleep(form.speed);

                        // vẽ lại j với j - 1
                        form.lbj.Location = new Point(j * 60, 80);
                        form.lbj1.Location = new Point((j - 1) * 60, 80);
                    }
                    form.array[j + 1] = form.array[j];
                    j = j - 1;

                }
                //arr[j + 1] = key;
                while (key.Location.X != form.LocationOfLabels[j + 1].X)
                {
                    key.Location = new Point(key.Location.X - 1, key.Location.Y);
                    Thread.Sleep(form.speed);
                }
                while (key.Location.Y != form.LocationOfLabels[j + 1].Y)
                {
                    key.Location = new Point(key.Location.X, key.Location.Y + 1);
                    Thread.Sleep(form.speed);
                }
                form.array[j + 1] = key;
                form.array[j + 1].ForeColor = Color.Black;
                form.array[j + 1].BackColor = Color.Yellow;
            }
            MessageBox.Show("Đã sắp xếp xong!", "Thông báo!");
            */
        }
    }
}
