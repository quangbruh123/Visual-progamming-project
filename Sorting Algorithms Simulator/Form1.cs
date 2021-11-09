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
        public int n = 0;
        public List<Item> list = new List<Item>();
        public int speed() // tốc độ cho hàm thread.sleep()
        {
            return ((int)(1 / (0.25 + acceleration * 0.25) * 1000)); 
        } 
        public float acceleration = 0; // gia tốc cho cái biến tốc độ tăng hoặc giảm tùy thích
        Random rand = new Random();
        public int sortOrder = 0; // 1 là tăng, -1 là giảm

        Thread thread;
        Thread checkThread;

        public Bitmap buffer;
        public Visualizer vslz;

        private int choose; // ghi nhớ đã lựa chọn thuật toán sắp xếp nào

        public static SortProject instance; // object của nguyên cái sort

        public SortProject()
        {
            InitializeComponent();
            btnReset.Enabled = false;
            btnPause.Enabled = false;
            rdAuto.Checked = true;

            instance = this;
            Control.CheckForIllegalCrossThreadCalls = false;
            acceleration = trackBar1.Value;

            buffer = new Bitmap(panel1.Size.Width, panel1.Size.Height);
            vslz = new Visualizer(ref buffer);

            typeof(Panel).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, panel1, new object[] { true });

            vslz.Reset();
            vslz.Test();
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
            list.Clear();
            vslz.Reset();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Chưa nhập gì cả thì phải nhập vào
            vslz.Reset();

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

                list.Clear();
                for (int i = 0; i < n; i++)
                {
                    Point defLoc = new Point(i * 60, 60);
                    Item item = new Item(rand.Next(0, 100), defLoc);

                    list.Add(item);
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

                if (n >= 20)
                {
                    MessageBox.Show("Không thể thêm được nữa!", "Chú ý!");
                    return;
                }

                Item item = new Item(rand.Next(0, 100));

                list.Add(item);
            }

            btnReset.Enabled = true;

            vslz.DrawAllItems();
        }

        private void rdIncrease_CheckedChanged(object sender, EventArgs e)
        {
            sortOrder = 1;
        }

        private void rdDecrease_CheckedChanged(object sender, EventArgs e)
        {
            sortOrder = -1;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // kiểm tra đầu vào
            if (list.Count == 0)
            {
                MessageBox.Show("Bạn hãy khởi tạo dữ liệu trước khi bắt đầu!", "Chú ý!");
                return;
            }

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
            btnReset.Enabled = false;

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
                    btnReset.Enabled = true;
                    rdIncrease.Enabled = true;
                    rdDecrease.Enabled = true;
                    break;
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            acceleration = trackBar1.Value;
            int k = speed();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(buffer, 0, 0);
        }

        public void Refresh()
        {
            panel1.Refresh();
        }
    }
}
