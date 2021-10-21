using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Sorting_Algorithms_Simulator
{
    public partial class SortProject : Form
    {
        // Khai báo các biến cần có
        public int n = 0; // số lượng phần tử
        public Label[] array = new Label[20]; // khởi tạo các nhãn
        public Point[] LocationOfLabels = new Point[20]; // khởi tạo các location cho từng label trong array
        public int speed = 10; // tốc độ cho hàm thread.sleep()
        public int acceleration = 0; // gia tốc cho cái biến tốc độ tăng hoặc giảm tùy thích
        Random rand = new Random();
        public int typeofSort = 0; // 1 là tăng, -1 là giảm

        Thread thread;
        Thread checkThread;

        public Label lbi, lbj;// label phụ để theo dõi 

        public Label lbmin; // label cho selection sort

        public Label lbj1; // label thêm cho bubble sort

        private int choose; // ghi nhớ đã lựa chọn thuật toán sắp xếp nào

        public static SortProject instance; // object của nguyên cái sort

        public SortProject()
        {
            InitializeComponent();
            btnReset.Enabled = false;
            btnPause.Enabled = false;
            rdAuto.Enabled = true;

            instance = this;
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void rdAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (rdAuto.Checked == true)
            {
                lbAmount.Enabled = true;
                txtAmount.Enabled = true;
                lbInput.Enabled = false;
                txtInput.Enabled = false;
            }
        }

        private void rdManual_CheckedChanged(object sender, EventArgs e)
        {
            if (rdManual.Checked == true)
            {
                lbAmount.Enabled = false;
                txtAmount.Enabled = false;
                lbInput.Enabled = true;
                txtInput.Enabled = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = null;
                
            }
            groupBox1.Controls.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Chưa nhập gì cả thì phải nhập vào
            if (rdAuto.Checked == true && txtAmount.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số lượng phần tử!", "Chú ý!");
                txtAmount.Focus();
                return;
            }
            if (rdManual.Checked == true && txtInput.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập phần tử!", "Chú ý!");
                txtInput.Focus();
                return;
            }

            if (rdAuto.Checked == true)
            {
                btnReset_Click(null, null);

                bool outcome = int.TryParse(txtAmount.Text, out n);
                if (outcome == false)
                {
                    MessageBox.Show("Vui lòng nhập đúng kiểu dữ liệu!", "Chú ý!");
                    return;
                }

                if (n > 20 || n < 2)
                {
                    MessageBox.Show("Vui lòng nhập số lượng phần tử trong khoảng từ 2 tới 20!", "Chú ý!");
                    return;
                }

                for (int i = 0; i < n; i++)
                {
                    CreateLabel(ref array[i], ref LocationOfLabels[i], ref rand, i);

                    groupBox1.Controls.Add(array[i]); // add vào màn hình
                }
            }
            else if (rdManual.Checked == true)
            {
                int input;
                bool outcome = int.TryParse(txtInput.Text, out input);
                if (outcome == false)
                {
                    MessageBox.Show("Vui lòng nhập đúng kiểu dữ liệu!", "Chú ý!");
                    return;
                }

                if (n == array.Length)
                {
                    MessageBox.Show("Không thể thêm được nữa!", "Chú ý!");
                    return;
                }

                CreateLabel(ref array[n], ref LocationOfLabels[n], ref rand, n);
                array[n].Text = txtInput.Text;

                groupBox1.Controls.Add(array[n]); // add vào màn hình

                n++; // tăng số lượng thực tế lên
            }

            btnReset.Enabled = true;
        }

        private void rdIncrease_CheckedChanged(object sender, EventArgs e)
        {
            typeofSort = 1;
        }

        private void rdDecrease_CheckedChanged(object sender, EventArgs e)
        {
            typeofSort = -1;
        }

        public void CreateLabel(ref Label a, ref Point b, ref Random rd, int i)
        {
            a = new Label(); //khởi tạo một đối tượng nhãn
            a.Text = rd.Next(0, 100).ToString(); //gán nội dung cho nhãn
            a.Name = "lb" + i.ToString(); //đặt tên cho nhãn
            b = new Point(); //khởi tạo một điểm
            b.X = i * 60; //gán hoành độ cho điểm
            b.Y = 60; //gán tung độ cho điểm
            a.Location = b; //gán vị trí cho nhãn bằng điểm vừa tạo ra
            a.Size = new System.Drawing.Size(35, 20); //đặt kích thước cho nhãn
            a.BorderStyle = BorderStyle.FixedSingle; //tạo đường viền
            a.BackColor = Color.Yellow; //màu nền của nhãn
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // kiểm tra đầu vào
            if (array[0] == null)
            {
                MessageBox.Show("Bạn hãy khởi tạo dữ liệu trước khi bắt đầu!", "Chú ý!");
                return;
            }

            CreateAdditionalLabel();

            if (rdSelection.Checked == true)
            {
                SortEngine se = new SelectionSort();

                thread = new Thread(new ThreadStart(se.Sort));
                thread.IsBackground = true;
                thread.Start();
            }
            else if (rdBubble.Checked == true)
            {
                SortEngine se = new BubbleSort();

                thread = new Thread(new ThreadStart(se.Sort));
                thread.IsBackground = true;
                thread.Start();
            }
            else if (rdInsertion.Checked == true)
            {
                SortEngine se = new InsertionSort();

                thread = new Thread(new ThreadStart(se.Sort));
                thread.IsBackground = true;
                thread.Start();
            }
            rdIncrease.Enabled = false;
            rdDecrease.Enabled = false;
            btnAdd.Enabled = false;
            btnStart.Enabled = false;
            btnPause.Enabled = true;

            // kiểm tra xem cái thread sort đã xong chưa 
            checkThread = new Thread(Check);
            checkThread.IsBackground = true;
            checkThread.Start();
        }
        public void Check()
        {
            while (true)
            {
                if ((thread.ThreadState & ThreadState.Aborted) == ThreadState.Aborted
                    || (thread.ThreadState & ThreadState.Stopped) == ThreadState.Stopped)
                {
                    btnStart.Enabled = true;
                    btnPause.Enabled = false;
                    btnAdd.Enabled = true;
                    rdIncrease.Enabled = true;
                    rdDecrease.Enabled = true;
                    DeleteAdditionalLabel();
                    break;
                }
            }
        }

        public void DeleteAdditionalLabel()
        {
            switch (choose)
            {
                case 1:
                    {
                        groupBox1.Controls.Remove(lbi);
                        groupBox1.Controls.Remove(lbj);
                        groupBox1.Controls.Remove(lbmin);
                        lbi = lbj = lbmin = null;
                        break;
                    }
                case 2:
                    {
                        groupBox1.Controls.Remove(lbi);
                        groupBox1.Controls.Remove(lbj);
                        groupBox1.Controls.Remove(lbj1);
                        lbi = lbj = lbj1 = null;
                        break;
                    }
                case 3:
                    {
                        groupBox1.Controls.Remove(lbi);
                        groupBox1.Controls.Remove(lbj);
                        groupBox1.Controls.Remove(lbj1);
                        lbi = lbj = lbj1 = null;
                        break;
                    }
                default:
                    break;
            }
        }

        public void CreateLabel(ref Label a, string text)
        {
            a = new Label(); //khởi tạo một đối tượng nhãn
            a.Text = text; //gán nội dung cho nhãn
            a.Size = new System.Drawing.Size(35, 20); //đặt kích thước cho nhãn
            a.BorderStyle = BorderStyle.FixedSingle; //tạo đường viền
            a.BackColor = Color.Yellow; //màu nền của nhãn
            a.TextAlign = ContentAlignment.MiddleCenter;
        }

        public void CreateAdditionalLabel()
        {
            // tạo thêm các nhãn phụ

            if (rdSelection.Checked == true)
            {
                CreateLabel(ref lbi, "i");
                CreateLabel(ref lbj, "j");
                CreateLabel(ref lbmin, "min");
                //đặt vị trí
                lbi.Location = new Point(0, 80);
                lbj.Location = new Point(60, 80);
                lbmin.Location = new Point(0, 100);

                if (rdDecrease.Checked == true)
                    lbmin.Text = "max";
                this.Invoke((MethodInvoker)delegate
                {
                    this.groupBox1.Controls.Add(lbi);
                    this.groupBox1.Controls.Add(lbj);
                    this.groupBox1.Controls.Add(lbmin);
                });
                choose = 1;
            }
            else if (rdBubble.Checked == true)
            {
                CreateLabel(ref lbi, "i");
                CreateLabel(ref lbj, "j");
                CreateLabel(ref lbj1, "j + 1");
                lbi.Location = new Point(0, 100);
                lbj.Location = new Point(0, 80);
                lbj1.Location = new Point(60, 80);

                this.Invoke((MethodInvoker)delegate
                {
                    this.groupBox1.Controls.Add(lbi);
                    this.groupBox1.Controls.Add(lbj);
                    this.groupBox1.Controls.Add(lbj1);
                });
                choose = 2;
            }
            else if (rdInsertion.Checked == true)
            {
                CreateLabel(ref lbi, "i");
                CreateLabel(ref lbj, "j");
                CreateLabel(ref lbj1, "j - 1");
                lbi.Location = new Point(0, 80);
                lbj.Location = lbi.Location;
                lbj1.Location = lbi.Location;


                this.Invoke((MethodInvoker)delegate
                {
                    this.groupBox1.Controls.Add(lbi);
                    this.groupBox1.Controls.Add(lbj);
                    this.groupBox1.Controls.Add(lbj1);
                });
                choose = 3;
            }
        }
    }
}
