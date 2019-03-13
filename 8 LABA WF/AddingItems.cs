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
    public partial class AddingItems : Form
    {
        public AddingItems()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        public StreamReader streamReader;
        public void ShowData()
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 2)
            {
                label1.Text = "Позиция";
                position.Enabled = true;
            }
            if (comboBox1.SelectedIndex < 2)
            {
                label1.Text = "";
                position.Enabled = false;
            }
        }
        private void SerializeStudentsToExtraStorage(int index)
        {
            Student newStudent = CreateNewStudent(index);
            FileStream storageDeserealizator = new FileStream("storage.bin", FileMode.Open);
            BinaryFormatter storageBDeserealizator = new BinaryFormatter();

            FileStream extraSerializator = new FileStream("extraStorage.bin", FileMode.Truncate);
            BinaryFormatter extraBSerializator = new BinaryFormatter();

            int numberOfStudents = Start.count;

            for (int i = 1; i <= numberOfStudents + 1; i++)
            {
                if (i == index)
                {
                    extraBSerializator.Serialize(extraSerializator, newStudent);
                    continue;
                }
                Student student = (Student)storageBDeserealizator.Deserialize(storageDeserealizator);
                if (i > index)
                    student.Index++;

                extraBSerializator.Serialize(extraSerializator, student);
            }
            storageDeserealizator.Close();
            extraSerializator.Close();
        }
        private void SerializeToCommonStorage()
        {
            FileStream storageSerealizator = new FileStream("storage.bin", FileMode.Truncate);
            BinaryFormatter storageBSerealizator = new BinaryFormatter();

            FileStream extraDeserializator = new FileStream("extraStorage.bin", FileMode.Open);
            BinaryFormatter extraBDeserializator = new BinaryFormatter();

            int numberOfStudents = Start.count;

            for (int i = 0; i < numberOfStudents; i++)
            {
                Student student = (Student)extraBDeserializator.Deserialize(extraDeserializator);
                storageBSerealizator.Serialize(storageSerealizator, student);               
            }
            storageSerealizator.Close();
            extraDeserializator.Close();
        }
        private Student CreateNewStudent(int index)
        {
            string name = nameTB.Text;
            int age = int.Parse(ageTB.Text);
            int group = int.Parse(groupTB.Text);
            int rating = int.Parse(rateTB.Text);

            Student student = new Student(name, age, group, rating, index);

            return student;
        }
        private void AddToBeginnig()
        {
            int position = 1;
            SerializeStudentsToExtraStorage(position);
            Start.count++;
            SerializeToCommonStorage();
        }

        private void AddingItems_Load(object sender, EventArgs e)
        {

        }

        private void position_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex < 2)
            {
                label1.Text = "";
                position.Enabled = false;
                if (comboBox1.SelectedIndex == 0)
                {
                    AddToBeginnig();
                }
                if(comboBox1.SelectedIndex == 1)
                {
                    AddToEnd();
                }
            }
            if (comboBox1.SelectedIndex == 2) 
            {
                AddToPosition();
            }
            Close();
            Dispose();

        }
        private void AddToEnd()
        {
            int position = Start.count + 1;
            SerializeStudentsToExtraStorage(position);
            Start.count++;
            SerializeToCommonStorage();
        }
        private void AddToPosition()
        {
            int index = InputIndex();
            SerializeStudentsToExtraStorage(index);
            Start.count++;
            SerializeToCommonStorage();
        }
        private int InputIndex()
        {
            return int.Parse(position.Text);
        }

    }
}
