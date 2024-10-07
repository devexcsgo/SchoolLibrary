using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary
{
    public class Student : Person
    {
        public int Semester { get; set; }
        public override string ToString()
        {
            return $"{Id}, {Name}, {Semester}";
        }

        public void ValidateSemester() 
        {
        if (Semester >= 1 || Semester <= 8) 
            {
                throw new ArgumentOutOfRangeException("Semester er ude for den tilladte rækkevide");
            }
        }
    }
}
