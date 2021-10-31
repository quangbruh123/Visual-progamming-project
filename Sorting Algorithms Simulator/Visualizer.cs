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
    public class Visualizer
    {
        //Có thể sử dụng bằng 2 cách:
        //Cách 1 (truyền thống): thay đổi giá trị các rồi cập nhật bằng form.Refresh và vẽ trong panel1_Paint.
        //      Khai báo bằng Visualizer [tên] = new Visualizer(e.Graphics); trong panel1_Paint
        //      Tự reset mọi thứ với mỗi lần sử dụng.
        //      Không cho phép tự vẽ tùy ý ngoài panel1_Paint, phụ thuộc vào thay đổi các giá trị.
        //      Animation thoải mái.
        //Cách 2 (đang sử dụng): vẽ mọi thứ trong realtime bằng cách tương tác bitmap rồi cập nhật bằng form.Refresh
        //      và vẽ lại bitmap này trong panel1_Paint.
        //      Khai báo bằng public Visualizer vslz; vslz = new Visualizer(ref buffer); trong đầu chương trình.
        //      Cần sử dụng Reset() để xóa tất cả mọi thứ với mỗi lần sử dụng (không khuyến khích). Hoặc vẽ đè lên có sẵn (Khuyến khích).
        //      Cho phép tự vẽ ngoài panel1_Paint.
        //      Cần nhiều não và Reset() mỗi frame nếu muốn animation.

        SortProject form = SortProject.instance;
        Graphics grph;
        Bitmap bminfo; //lưu ý: chỉ sử dụng để lưu thông tin.

        public Visualizer(int x, int y)
        {
            //Vẽ lên 1 bitmap thay vì graphic.
            Bitmap buffer = new Bitmap(x, y);
            grph = Graphics.FromImage(buffer);
            bminfo = buffer;
        }

        public Visualizer(ref Bitmap b)
        {
            grph = Graphics.FromImage(b);
            bminfo = b;
        }

        public Visualizer(Graphics g)
        {
            grph = g;
        }

        public void Test()
        {
            Pen pen = new Pen(Color.Black, 5f);
            Brush br = new System.Drawing.SolidBrush(Color.White);

            Rectangle rect = new Rectangle(10, 10, 1146, 243);
            grph.DrawRectangle(pen, rect);
            grph.FillRectangle(br, rect);

            
            Font f = new Font(FontFamily.GenericSansSerif, 50, FontStyle.Regular, GraphicsUnit.Pixel);
            WriteString("Test", f, Color.Black, new Point(533, 80));
            Refresh();
        }

        public void DrawItem(Item i)
        {
            Rectangle rect = new Rectangle(i.location.X, i.location.Y, 20, 20);

            System.Drawing.SolidBrush br = new System.Drawing.SolidBrush(i.backgroundColor);
            grph.FillRectangle(br,rect);
            br = new System.Drawing.SolidBrush(i.textColor);
            grph.DrawString(i.data.ToString(), SystemFonts.DefaultFont, br, i.location);
            Refresh();
        }

        public void WriteString(string str, Font f, Color c, Point p)
        {
            grph.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            System.Drawing.SolidBrush br = new System.Drawing.SolidBrush(c);
            grph.DrawString(str, f, br, p);
            Refresh();
        }

        public void Refresh()
        {
            form.Refresh();
        }

        public void DrawAllItems()
        {
            foreach (Item i in form.list)
            {
                DrawItem(i);
            }
            Refresh();
        }

        public void ChangeColor(Item i, Color c)
        {
            i.backgroundColor = c;
        }

        public void ResetColor(Item i)
        {
            i.backgroundColor = Color.Yellow;
        }

        public void Reset() //Reset lại bitmap để sử dụng cho cách 2.
        {
            form.buffer = new Bitmap(form.buffer.Size.Width, form.buffer.Size.Height);
            grph = Graphics.FromImage(form.buffer);
            Refresh();
        }
    }
}
