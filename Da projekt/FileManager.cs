using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;

namespace Da_projekt
{
    public class FileManager
    {
        public string inputDir; //Thư mục chứa save files;
        public List<string> files = new List<string>(); //Danh sách save file có trong thư mục
        public static FileManager fileManager;

        public FileManager()
        {
            fileManager = this;
        }

        public FileManager(string directory)
        {
            inputDir = directory;
            fileManager = this;
            this.Update();
        }

        public void SetNewInputDir(string path)
        {
            inputDir = path;

            files = new List<string>();
            this.Update();
        }

        public void Update()
        {
            DirectoryInfo d = new DirectoryInfo(inputDir);
            FileInfo[] Files = d.GetFiles("*.txt");

            foreach (FileInfo file in Files)
            {
                files.Add(file.Name);
            }
        }

        public string GetDirectory(string name)
        {
            return inputDir + "\\" + name;
        }

        public string Open(ref string name)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string n = System.IO.File.ReadAllText(openFileDialog.FileName);
                name = openFileDialog.FileName;
                return n;
            } else
                return null;
        }

        public void SaveText(string str)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, str);
            }
            else
                return;
        }

        public void Save(string[] str)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllLines(saveFileDialog.FileName, str);
            }
            else
                return;
        }

        public string Read(string directory)
        {
            return System.IO.File.ReadAllText(directory);
        }

        public void WriteFile(string directory, string content)
        {
            using (StreamWriter outputFile = new StreamWriter(directory))
            {
                outputFile.WriteLine(content);
            }
        }
    }
}
