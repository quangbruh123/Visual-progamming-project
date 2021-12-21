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
                case "SwitchDes":
                    return GetSwitch("NormalSwitch", item1, item2);
                case "SwitchDesLR":
                    return GetSwitch("LRSwitch", item1, item2);
                case "SwitchDesLP":
                    return GetSwitch("LPSwitch", item1, item2);
                case "DescriptQS":
                    return $"Xét pivot là phần tử thứ {item1} (màu vàng), phần tử bắt đầu của mảng bên trái là phần tử thứ {item2}, phần tử bắt đầu của mảng bên trái là phần tử thứ {item3}.";
                case "CompareBB":
                    return $"Xét cặp thứ {item1} - {item2}";
                case "AnnounceInsert":
                    return $"Phần tử thứ {item1} cũ đã chèn tới vị trí mới là vị trí thứ {item2}";
                case "SaveLeft":
                    return $"Lưu phần tử thứ {item1} ở mảng trái để cho việc đổi chỗ.";
                case "SaveRight":
                    return $"Lưu phần tử thứ {item1} ở mảng phải để cho việc đổi chỗ.";
                case "AnnounceOrder":
                    return "Đã xét hết các phần tử trừ pivot trong mảng.";
                default:
                    return null;
            }
        }

        private string GetDone(string type)
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

        private string GetIntro(string type)
        {
            switch (type)
            {
                case "BubbleSort":
                    return "- Đây là Bubble sort, là thuật toán sort đơn giản nhất.\n\n- Ý tưởng: Thực hiện việc sắp xếp dãy số bằng cách lặp lại công việc đổi chỗ 2 số liên tiếp nhau nếu nó sai thứ tự."; ;
                case "InsertionSort":
                    return "- Đây là Insertion sort, cách thức nó hoạt động như cách bạn sắp xếp các tấm trong bộ bài.\n\n- Ý tưởng: Giá trị của các phần tử nào không đúng so với các phần tử còn lại sẽ được chọn và đặt ở vị trí đúng so với dãy số đã được sắp xếp.";
                case "InterchangeSort":
                    return "- Đây là Interchange sort, là thuật toán sắp xếp đổi chỗ trực tiếp.\n\n- Ý tưởng: Thuật toán sẽ duyệt qua tất cả các cặp giá trị trong mảng và hoán vị 2 giá trị trong 1 cặp nếu cặp giá trị đó không thỏa mãn thứ tự của dãy số (tăng dần hoặc giảm dần).";
                case "SelectionSort":
                    return "- Đây là Selection Sort, là thuật toán sort chia dãy số thành 2 mảng con: 1 mảng đã được sắp xếp và 1 mảng chửa được sắp xếp.\n\n- Ý tưởng: Thuật toán sẽ tìm phần tử nhỏ nhất trong mảng phần từ chưa được sắp xếp, sau đó sẽ đưa phần tử đấy sang đầu đoạn chưa sắp xếp. Khi xết phần tử tiếp theo thì không xét thêm phần tử được chọn lúc trước.";
                case "QuickSort":
                    return "- Đây là Quick Sort, là thuật toán 'chia để trị'.\n\n- Ý tưởng: Chọn phần tử cuối của mảng được xét là điểm đánh dấu (pivot), thực hiện chia mảng theo pivot bằng cách đưa các phần tử nhỏ hơn pivot vào phía bên trái, còn lại về phía bên phải. Tiếp theo sẽ thực hiện quick sort với mỗi mảng (mảng bên trái và mảng bên phải của pivot) liên tục cho đến khi mảng đã được sắp xếp. ";
                default:
                    return null;
            }
        }

        private string GetSwitch(string type, int item1, int item2)
        {
            switch (type)
            {
                case "NormalSwitch":
                    return $"Phần tử thứ {item1} và {item2} đổi chỗ";
                case "LRSwitch":
                    return $"Phần tử thứ {item1} ở mảng bên trái và phần tử thứ {item2} ở mảng bên phải đổi chỗ cho nhau.";
                case "LPSwitch":
                    return $"Do đã xét hết các phần tử, nên phần tử thứ {item1} ở mảng bên trái và phần tử pivot ở vị trí thứ {item2} đổi chỗ cho nhau.";
                default:
                    return null;
            }
        }
    }
}
