using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace _8_LABA_WF
{
    public partial class DeleteFM : Form
    {
        public DeleteFM()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                //key
                label1.Text = "Имя Фамилия";
            }
            else
            {
                //index
                label1.Text = "Номер";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                SelectByName();
            }
            if (comboBox1.SelectedIndex == 1)
            {
                SelectByNumber();
            }
            Close();
            Dispose();
        }   


        private void SelectByName()
        {
            string name = InputName();

            SerializeToExtraByName(name);
            SerializeToStorageByName();
        }
        private string InputName()
        {
            return textBox1.Text;
        }
        private void SerializeToExtraByName(string name)
        {
            FileStream storageDeserealizator = new FileStream("storage.bin", FileMode.Open);
            BinaryFormatter storageBDeserealizator = new BinaryFormatter();

            FileStream extraSerializator = new FileStream("extraStorage.bin", FileMode.Truncate);
            BinaryFormatter extraBSerializator = new BinaryFormatter();

            int numberOfStudent = Start.count;
            int indexOfDeleted = 0;
            for (int i = 1; i <= numberOfStudent; i++)
            {
                Student student = (Student)storageBDeserealizator.Deserialize(storageDeserealizator);
                if (student.Name == name)
                {
                    indexOfDeleted = student.Index;
                    continue;
                }
                if (student.Index > indexOfDeleted)
                    student.Index--;
                extraBSerializator.Serialize(extraSerializator, student);
            }
            Start.count--;
            storageDeserealizator.Close();
            extraSerializator.Close();
        }
        private void SerializeToStorageByName()
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


        private void SelectByNumber()
        {
            int number = InputNumber();

            SerializeToExtraByNum(number);
            SerializeToStorageByNum();

        }
        private int InputNumber()
        {
            return int.Parse(textBox1.Text);
        }
        private void SerializeToExtraByNum(int number)
        {
            FileStream storageDeserealizator = new FileStream("storage.bin", FileMode.Open);
            BinaryFormatter storageBDeserealizator = new BinaryFormatter();

            FileStream extraSerializator = new FileStream("extraStorage.bin", FileMode.Truncate);
            BinaryFormatter extraBSerializator = new BinaryFormatter();

            int numberOfStudent = Start.count;

            for (int i = 1; i <= numberOfStudent; i++)
            {
                Student student = (Student)storageBDeserealizator.Deserialize(storageDeserealizator);
                if (student.Index == number)
                {
                    continue;
                }
                if (student.Index > number)
                    student.Index--;
                extraBSerializator.Serialize(extraSerializator, student);
            }
            Start.count--;
            storageDeserealizator.Close();
            extraSerializator.Close();
        }
        private void SerializeToStorageByNum()
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
    }
}
