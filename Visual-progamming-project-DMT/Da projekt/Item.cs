using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Da_projekt
{
    public class Item
    {
        public int data;
        public Point location = new Point();
        public Color color = Colors.White;

        public Item(Item item)
        {
            data = item.data;
            location = item.location;
            color = item.color;
        }
        public Item(int i)
        {
            data = i;
        }

        public Item(int i, Point defLocation)
        {
            data = i;
            location = defLocation;
        }

        public void changeColor(Color targetColor)
        {
            color = targetColor;
        }

        public void ResetColor()
        {
            color = Colors.White;
        }

        public Brush brush()
        {
            return new SolidColorBrush(color);
        }

        public void drawItemSelectionSort(DrawingContext dc, Rect rect)
        {
            float spacing = ((float)rect.Width);
            dc.DrawRectangle(brush(), new Pen(Brushes.Black, 0.5f), rect);

            FormattedText text = new FormattedText(data.ToString(), new System.Globalization.CultureInfo("en-us"), FlowDirection.RightToLeft, new Typeface("Verdana"), spacing / 5, Brushes.White);
            Point textLoc = new Point(rect.X + spacing / 2, rect.Y - spacing / 2.5);
            dc.DrawText(text, textLoc);
        }
        public void DrawItemMergeSort(DrawingContext dc, Rect rect)
        {
            float space = ((float)rect.Width); // chiều dài cái ô chứa số
            dc.DrawRectangle(brush(), new Pen(Brushes.Black, 0.5f), rect);

            FormattedText text = new FormattedText(data.ToString(), new System.Globalization.CultureInfo("en-us"), FlowDirection.RightToLeft, new Typeface("Verdana"), space / 3, Brushes.Black);
            Point textLoc = new Point(rect.X + 20, rect.Y);
            dc.DrawText(text, textLoc);
        }
    }
}
