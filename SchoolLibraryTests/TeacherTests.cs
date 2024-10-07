using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary.Tests
{
    [TestClass()]
    public class TeacherTests
    {
        [TestMethod()]
        public void ValidateSalaryTest()
        {
            Teacher teacherPositiveSalary = new Teacher()
            {
                Name = "Kød",
                Salary = 100
            };

            teacherPositiveSalary.ValidateSalary();
            Assert.AreEqual(100, teacherPositiveSalary.Salary);

            Teacher teacherNegativeSalary = new Teacher() { Id=1, Name="abe", Salary=-100};

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => teacherNegativeSalary.ValidateSalary());
        }

        [TestMethod()]
        public void ValidateNameTest() 
        {
            Teacher nameNull = new Teacher() { Id=3, Salary = 100 };
            Teacher nameIs0 = new Teacher() { Id = 4, Name = "", Salary = 100 };

            
            Assert.ThrowsException<ArgumentNullException>(() => nameNull.ValidateName());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>nameIs0.ValidateName());
        }

        [TestMethod()]
        public void ToStringTest() 
        {
        Teacher aTeacher = new Teacher() { Id=5, Name="Per",Salary=100 };
            aTeacher.ToString();
        }

    }
}