using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace _8_LABA_WF
{
    [Serializable]
    public class Person 
    {
        string name;        
        int age;
        DateTime dateOfCreating;
        
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value > 0 && value < 99)
                {
                    age = value;
                }
                else
                {
                    age = 0;
                }
            }
        }

        public Person()
        { 
            this.name = null;
            this.age = 0;
            dateOfCreating = DateTime.Now;
        }
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
            dateOfCreating = DateTime.Now;
        }

        public DateTime GetData()
        {
            return dateOfCreating;
        }   
    }
}
