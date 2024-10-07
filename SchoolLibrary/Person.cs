using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SchoolLibrary
{
    public class Person
    {
        public int Id { get; set; }
        public string ?Name { get; set; }

        public override string ToString()
        {
            return $"{Id}, {Name}";
        }
        public void ValidateName()
        {
            if (Name == null)
            {
                throw new ArgumentNullException("null");
            }
            if (Name.Length == 0)
            {
                throw new ArgumentOutOfRangeException("Enter atleast 1 letter");
            }

        }
    }
}
