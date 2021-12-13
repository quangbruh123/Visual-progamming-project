using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Da_projekt
{
    public class Description
    {
        public enum BubbleSortDes
        {
            Intro,
            Compare,
            Done,
            Switch,
            Starting,
        }
        public enum InsertionSortDes
        {
            Intro,
            Compare,
            Announce,
            Done,
            Nochange,
            Switch,
            Starting,
        }
        public enum InterchangeSortDes
        {
            Intro,
            Compare,
            Announce,
            Nochange,
            Switch,
            Starting,
            Done,
            DoneIC,
        }

        public enum SelectionSortDes
        {
            Intro,
            Compare,
            Done,
            Switch,
            Starting,
        }

        public enum QuickSortDes
        {
            Intro,
            Done,
            Diff,
            StartingLeft,
            StartingRight,
            Switch,
        }

        public enum MergeSortDes
        {

        }

        public Description()
        {
        }

        
        /*public string BubbleSort(BubbleSortDes type, int item1, int item2)
        {
            //BubbleSort
            switch (type)
            {
                case BubbleSortDes.Intro:
                    return GetIntro("BubbleSort");
                case BubbleSortDes.Done:
                    return GetDone("BubbleSort");
                case BubbleSortDes.Compare:
                    return $"Xét cặp thứ {item1} - {item2}";
                case BubbleSortDes.Starting:
                    return "Xét phần tử thứ " + item1;
                case BubbleSortDes.Switch:
                    return GetSwitch(item1, item2);
                default:
                    return null;
            }
        }

        public string InsertionSort(InsertionSortDes type, int item1, int item2)
        {
            //InsertionSort
            switch (type)
            {
                case InsertionSortDes.Intro:
                    return GetIntro("InsertionSort");
                case InsertionSortDes.Done:
                    return GetDone("InsertionSort");
                case InsertionSortDes.Announce:
                    return $"Phần tử thứ {item1} cũ đã chèn tới vị trí mới là vị trí thứ {item2}";
                case InsertionSortDes.Nochange:
                    return "Xét qua mọi phần tử ở bên trái phần tử được xét, nhận thấy không có phần tử nào lớn hơn phần tử này cả. Qua đó xét phần tử tiếp theo.";
                case InsertionSortDes.Starting:
                    return "Xét phần tử thứ " + item1;
                case InsertionSortDes.Switch:
                    return GetSwitch(item1, item2);
                default:
                    return null;
            }
        }

        public string InterchangeSort(InterchangeSortDes type, int item1, int item2)
        {
            //InterchangeSort
            switch (type)
            {
                case InterchangeSortDes.Intro:
                    return GetIntro("InterchangeSort");
                case InterchangeSortDes.Done:
                    return GetDone("InterchangeSort");
                case InterchangeSortDes.DoneIC:
                    return $"Đã xong vòng lặp của phần tử thứ {item1}, bây giờ xét phần tử tiếp theo.";
                case InterchangeSortDes.Announce:
                    return $"Phần tử thứ {item1} cũ đã chèn tới vị trí mới là vị trí thứ {item2}";
                case InterchangeSortDes.Nochange:
                    return "Xét qua mọi phần tử ở bên trái phần tử được xét, nhận thấy không có phần tử nào lớn hơn phần tử này cả. Qua đó xét phần tử tiếp theo.";
                case InterchangeSortDes.Starting:
                    return "Xét phần tử thứ " + item1;
                case InterchangeSortDes.Switch:
                    return GetSwitch(item1, item2);
                default:
                    return null;
            }
        }

        public string MergeSort(string type, int item1, int item2)
        {
            //MergeSort
            switch (type)
            {
                default:
                    return null;
            }
        }

        public string QuickSort(QuickSortDes type, int item1, int item2)
        {
            //QuickSort
            switch (type)
            {
                case QuickSortDes.Intro:
                    return GetIntro("QuickSort");
                case QuickSortDes.Done:
                    return GetDone("QuickSort");
                case QuickSortDes.Diff:
                    return "Xét các phần tử tiếp theo của 2 mảng";
                case QuickSortDes.StartingLeft:
                    return "Xét mảng bên trái, phần tử thứ " + item1;
                case QuickSortDes.StartingRight:
                    return "Xét mảng bên phải, phần tử thứ " + item1;
                case QuickSortDes.Switch:
                    return GetSwitch(item1, item2);
                default:
                    return null;
            }
        }*/

        public string GetAction(string type, int item1, int item2, int item3)
        {
            switch (type)
            {
                case "IntroBB":
                    return GetIntro("BubbleSort");
                case "IntroInsert":
                    return GetIntro("InsertionSort");
                case "IntroInterchange":
                    return GetIntro("InterchangeSort");
                case "IntroSS":
                    return GetIntro("SelectionSort");
                case "IntroQS":
                    return GetIntro("QuickSort");
                case "DiffQS":
                    return "Xét các phần tử tiếp theo của 2 mảng";
                case "DoneBB":
                    return $"Đã xong, bây giờ vị trí cuối cùng được xử lý là phần tử lớn nhất";
                case "NoChangeInsert":
                    return "Xét qua mọi phần tử ở bên trái phần tử được xét, nhận thấy không có phần tử nào lớn hơn phần tử này cả. Qua đó xét phần tử tiếp theo.";
                case "Done":
                    return "Dãy số đã được xếp xong!";
                case "Starting":
                    return "Xét phần tử thứ " + item1;
                case "StartingSub":
                    return "Xét phần tử phụ thứ " + item1;
                case "StartingLeft":
                    return "Xét mảng bên trái, phần tử thứ " + item1;
                case "StartingRight":
                    return "Xét mảng bên phải, phần tử thứ " + item1;
                case "DoneIC":
                    return $"Đã xong vòng lặp của phần tử thứ {item1}, bây giờ xét phần tử tiếp theo.";
                case "ConfirmMin":
                    return $"Nhận thấy phần tử thứ {item1} bé hơn phần tử chính đang xét, gán cho min = phần tử này";
                case "Switch":
                    return GetSwitch(item1, item2);
                case "DescriptQS":
                    return $"Xét pivot là phần tử thứ {item1} (màu vàng), phần tử bắt đầu của mảng bên trái là phần tử thứ {item2}, phần tử bắt đầu của mảng bên trái là phần tử thứ {item3}.";
                case "CompareBB":
                    return $"Xét cặp thứ {item1} - {item2}";
                case "AnnounceInsert":
                    return $"Phần tử thứ {item1} cũ đã chèn tới vị trí mới là vị trí thứ {item2}";
                default:
                    return null;
            }
        }

        private string GetIntro(string type)
        {
            switch (type)
            {
                case "Bubblesort":
                    return "Đã xong, bây giờ vị trí cuối cùng được xử lý là phần tử lớn nhất";
                case "InsertionSort":
                    return "Dãy số đã được xếp xong!";
                case "InterchangeSort":
                    return "Dãy số đã được xếp xong!";
                case "SelectionSort":
                    return "Dãy số đã được xếp xong!";
                case "QuickSort":
                    return "Dãy số đã được xếp xong!";
                default:
                    return null;
            }
        }

        private string GetDone(string type)
        {
            switch (type)
            {
                case "Bubblesort":
                    return "Đây là BB sort.";
                case "InsertionSort":
                    return "Đây là Insertion sort.";
                case "InterchangeSort":
                    return "Đây là Interchange sort.";
                case "SelectionSort":
                    return "Đây là Selection Sort";
                case "QuickSort":
                    return "Đây là Quick Sort";
                default:
                    return null;
            }
        }

        private string GetSwitch(int item1, int item2)
        {
            return $"Phần tử thứ {item1} và {item2} đổi chỗ";
        }
    }
}
