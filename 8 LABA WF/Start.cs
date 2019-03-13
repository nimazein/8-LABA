using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace _8_LABA_WF
{
    public partial class Start : Form
    {
        
        public Start()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fileStream = new FileStream("storage.bin", FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            StreamReader streamReader = ChoseFile();

            int i = 1;
            while (!streamReader.EndOfStream)
            {
                Student student = CreateObject(streamReader, i);
                binaryFormatter.Serialize(fileStream, student);
                i++;
            }
            fileStream.Close();
            streamReader.Close();
            MainForm mf = new MainForm();
            mf.ShowData();
            mf.ShowDialog();

        }
        public static int count;
        private StreamReader ChoseFile()
        {
            StreamReader streamReader = null;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    count = System.IO.File.ReadAllLines(filePath).Length;
                    streamReader = new StreamReader(filePath, Encoding.GetEncoding(65001));
                }
                return streamReader;
            }

        }
        private Student CreateObject(StreamReader streamReader, int i)
        {
            string currentLine = streamReader.ReadLine();
            char[] h = { ' ' };
            string[] words = currentLine.Split(h, StringSplitOptions.RemoveEmptyEntries);

            string name = words[0] + ' ' + words[1];
            int age = int.Parse(words[2]);
            int group = int.Parse(words[3]);
            int rating = int.Parse(words[4]);

            Student student = new Student(name,age,group,rating, i);

            return student;
        }
        
            
        
    }
}
