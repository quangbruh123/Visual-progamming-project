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
        public string outputDir; //Thư mục chứa save files;
        public List<string> files = new List<string>(); //Danh sách save file có trong thư mục
        public static FileManager fileManager;

        public FileManager()
        {
            fileManager = this;
        }

        public FileManager(string directory)
        {
            outputDir = directory;
            fileManager = this;
            this.Update();
        }

        public void Update()
        {
            DirectoryInfo d = new DirectoryInfo(outputDir);
            FileInfo[] Files = d.GetFiles("*.txt");

            foreach (FileInfo file in Files)
            {
                files.Add(file.Name);
            }
        }

        public string GetDirectory(string name)
        {
            return outputDir + "\\" + name;
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
