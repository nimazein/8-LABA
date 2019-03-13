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
using System.Text.RegularExpressions;

namespace _8_LABA_WF
{
    public partial class CorrectRecords : Form
    {
        public CorrectRecords()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }


        static int indexOfChanged;

        
      

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            textBox1.Enabled = false;

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    // Ключ
                    FindItemWithKey();
                    break;
                case 1:
                    // Номер
                    FindItemWithNumber();
                    break;
                
            }
            button1.Enabled = false;
        }
        private void ShowThisStudent(Student student)
        {
            string name = student.Name;
            string age = student.Age.ToString();
            string group = student.Group.ToString();
            string rating = student.Rating.ToString();

            textBox2.Text = name;
            textBox3.Text = group;
            textBox4.Text = rating;
            textBox5.Text = age;
        }

        #region WithKey
        private void FindItemWithKey()
        {
            FileStream storageDeserealizator = new FileStream("storage.bin", FileMode.Open);
            BinaryFormatter storageBDeserealizator = new BinaryFormatter();

            FileStream extraSerializator = new FileStream("extraStorage.bin", FileMode.Create);
            BinaryFormatter extraBSerializator = new BinaryFormatter();

            Student student = new Student();
            string soughtForName = InputName();

            int numberOfStudents = Start.count;
            for (int i = 1; i <= numberOfStudents; i++)
            {
                student = (Student)storageBDeserealizator.Deserialize(storageDeserealizator);
                if (student.Name == soughtForName)
                {
                    indexOfChanged = i;
                    ShowThisStudent(student);
                    continue;
                }
                //  Cохранили все, кроме изменяемого
                extraBSerializator.Serialize(extraSerializator, student);
            }
            storageDeserealizator.Close();
            extraSerializator.Close();

        }
        private string InputName()
        {
            return textBox1.Text;
        }        
        #endregion


        #region WithNumber
        private void FindItemWithNumber()
        {
            Student student = new Student();
            Student studentForChange = new Student();
            int studentNumber = InputNumber();

            int numberOfStudents = Start.count;

            FileStream storageDeserealizator = new FileStream("storage.bin", FileMode.Open);
            BinaryFormatter storageBDeserealizator = new BinaryFormatter();

            FileStream extraSerializator = new FileStream("extraStorage.bin", FileMode.Create);
            BinaryFormatter extraBSerializator = new BinaryFormatter();

            for (int i = 1; i <= numberOfStudents; i++)
            {
                student = (Student)storageBDeserealizator.Deserialize(storageDeserealizator);
                if (i == studentNumber)
                {
                    indexOfChanged = i;
                    studentForChange = student;
                    continue;
                }

                //  Cохранили все, кроме изменяемого
                extraBSerializator.Serialize(extraSerializator, student);
            }
            storageDeserealizator.Close();
            extraSerializator.Close();


            ShowThisStudent(studentForChange);
        }
        private int InputNumber()
        {
            return int.Parse(textBox1.Text);
        }
        #endregion


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    // Ключ
                    label1.Text = "Фамилия Имя";
                    break;
                case 1:
                    // Номер
                    label1.Text = "Номер";
                    break;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckRightInput();
            Student student = CreateStudent();
            
            SerializeOnceMore(student);

            Close();
            Dispose();          

        }
        private Student CreateStudent()
        {
            string name = textBox2.Text;
            int group = int.Parse(textBox3.Text);
            int rating = int.Parse(textBox4.Text);
            int age = int.Parse(textBox5.Text);

            Student student = new Student(name, age, group, rating, indexOfChanged);

            return student;
        }
        private void CheckRightInput()
        {
            // Чекнуть всё
        }
        private void SerializeOnceMore(Student changedStudent)
        {
            
            FileStream storageSerializator = new FileStream("storage.bin", FileMode.Truncate);
            BinaryFormatter storageBSerializator = new BinaryFormatter();

            FileStream extraDeserializator = new FileStream("extraStorage.bin", FileMode.Open);
            BinaryFormatter extraBDeserializator = new BinaryFormatter();

            int numberOfStudents = Start.count;
            for (int i = 1; i <= numberOfStudents; i++)
            {
                if (i == changedStudent.Index)
                {
                    storageBSerializator.Serialize(storageSerializator, changedStudent);
                    continue;
                }
                Student student = (Student)extraBDeserializator.Deserialize(extraDeserializator);
                storageBSerializator.Serialize(storageSerializator, student);
            }
            storageSerializator.Close();
            extraDeserializator.Close();
         
        }
        



        

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char symbol = e.KeyChar;
            if ((symbol <= 48 || symbol >= 57) && symbol != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        static int i = 0;

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (i <= 1)
            {
                if (e.KeyChar == 32)
                {
                    i++;
                }
                char symbol = e.KeyChar;
                if (symbol <= 192 && symbol != 8 && symbol != 32)
                {
                    e.Handled = true;
                }
            }
            else
                e.Handled = true;

            
            

           
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char symbol = e.KeyChar;
            if ((symbol <= 48 || symbol >= 57) && symbol != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char symbol = e.KeyChar;
            if ((symbol <= 48 || symbol >= 57) && symbol != 8)
            {
                e.Handled = true;
            }
        }
    }
}
