using SchoolLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibraryTests
{
    [TestClass()]
    public class StudentTest
    {
        [TestMethod()]
        public void ValidateNameTest()
        {
            Student nameNull = new Student() { Id = 3, Semester = 3 };
            Student nameIs0 = new Student() { Id = 4, Name = "", Semester = 3 };


            Assert.ThrowsException<ArgumentNullException>(() => nameNull.ValidateName());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => nameIs0.ValidateName());
        }

        [TestMethod()]
        public void StudentSemesterTest()
        {
            Student studentSemesterIs0 = new Student() { Id = 3, Name = "Lams", Semester = 0 };
            Student studentSemesterIs8 = new Student() { Id = 4, Name = "jamz", Semester = 8 };
            Student studentSemesterIsNull = new Student() { Id = 5, Name = "Kiko" };

            studentSemesterIs0.ValidateSemester();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => studentSemesterIs0.ValidateSemester());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => studentSemesterIs8.ValidateSemester());
            Assert.ThrowsException<ArgumentNullException>(() => studentSemesterIsNull.ValidateSemester());
        }
    }
}
