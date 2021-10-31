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
            /*
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
                    if (int.Parse(form.array[min].Text) * form.sortOrder > int.Parse(form.array[j].Text) * form.sortOrder)
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
            */
        }
    }
}
