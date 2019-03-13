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
    public partial class MainForm : Form
    {
        public string Item0 = "По ключу";
        public string Item1 = "По номеру";
        public string Item2 = "В начало";
        public string Item3 = "В конец";
        public string Item4 = "В позицию с заданным номером";

        
        public MainForm()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        void AddItemsForAdding()
        {
            
        }
        void AddDefaultItems()
        {
            
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Start start = new Start();
            start.Close();
            if (comboBox1.SelectedIndex == 0)
            {
                // Корректировать записи
                CorrectRecords correct = new CorrectRecords();
                correct.ShowDialog();
            }
            if (comboBox1.SelectedIndex == 1)
            {
                // Добавить запись
                AddingItems adding = new AddingItems();
                adding.ShowDialog();
            }
            if (comboBox1.SelectedIndex == 2)
            {
                // Delete
                DeleteFM delete = new DeleteFM();
                delete.ShowDialog();                
            }
            ShowData();

        }


        public StreamReader streamReader;

        

        public void ShowData()
        {
            dataGridView1.Rows.Clear();
            FileStream storageDeserealizator = new FileStream("storage.bin", FileMode.Open);
            BinaryFormatter storageBDeserealizator = new BinaryFormatter();

            int numberOfStudents = Start.count;

            for (int i = 0; i < numberOfStudents; i++)
            {
                Student student = (Student)storageBDeserealizator.Deserialize(storageDeserealizator);

                string number = student.Index.ToString();
                string name = student.Name;
                string age = student.Age.ToString();
                string group = student.Group.ToString();
                string rating = student.Rating.ToString();


                dataGridView1.Rows.Add(number, name, age, group, rating);

            }
            storageDeserealizator.Close();           
        }

        void Correct()
        {
            
        }

        void AddRecord()
        {
            AddingItems a = new AddingItems();
            a.ShowData();

            a.ShowDialog();
        }
        void CopyFile()
        {

        }
        void AddRecordToBeginning()
        {

        }
        void AddRecordToEnd()
        {

        }
        void AddRecordToPosition()
        {

        }

        void Delete()
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void LoadData()
        {
            
        }
    }
}
