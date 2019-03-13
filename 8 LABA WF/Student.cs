using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace _8_LABA_WF
{
    [Serializable]
    public class Student : Person
    {
        
        protected int group;
        protected int rating;
        protected int index;

        public int Group
        {
            set
            {
                group = value;
            }
            get
            {
                return group;
            }
        }
        public int Rating
        {
            set
            {
                rating = value;
            }
            get
            {
                return rating;
            }
        }
        public int Index
        {
            set
            {
                index = value;
            }
            get
            {
                return index;
            }
        }
        public Student(string name, int age, int group, int rating, int index)
            :base(name,age)
        {
            this.index = index;
            this.group = group;
            this.rating = rating;
        }
        public Student()
        {
                
        }

    }
}
