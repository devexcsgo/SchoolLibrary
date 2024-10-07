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
    public class TeacherRepositoryTests
    {
        [TestMethod()]
        public void AddTeacherTest()
        {
            // Arrange
            TeacherRepository repository = new TeacherRepository();
            Teacher addTeacherNr1 = new Teacher() { Id = 1, Name = "John", Salary = 100 };
            Teacher addTeacherNr2 = new Teacher() { Id = 2, Name = "Per", Salary = 1000 };

            // Act
            repository.AddTeacher(addTeacherNr1);
            repository.AddTeacher(addTeacherNr2);

            // Assert 
            Assert.AreEqual(1, addTeacherNr1.Id);
            Assert.AreEqual(2, addTeacherNr2.Id);
        }

        [TestMethod()]
        public void GetTeachersTest()
        {
            // Arrange
            TeacherRepository repository = new TeacherRepository();
            Teacher getTest1 = new Teacher() { Id = 3, Name = "Ivan", Salary = 1300 };
            Teacher getTest2 = new Teacher() { Id = 4, Name = "PerGaming", Salary = 10400 };


            // Act
            repository.AddTeacher(getTest1);
            repository.AddTeacher(getTest2);
            repository.GetTeachers().Count();

            // Assert

            Assert.AreEqual(2, repository.GetTeachers().Count());
        }

        [TestMethod()]
        public void GetTest()
        {
            TeacherRepository repository = new TeacherRepository();
            Teacher getTest3 = new Teacher() { Id = 1, Name = "Ivan", Salary = 1300 };
            Teacher getTest4 = new Teacher() { Id = 2, Name = "Ivan", Salary = 1300 };


            repository.AddTeacher(getTest3);
            repository.AddTeacher(getTest4);

            Assert.AreEqual(1, getTest3.Id);
            Assert.AreEqual(2, getTest4.Id);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            TeacherRepository repository = new TeacherRepository();
            Teacher removeTest1 = new Teacher() { Id = 1, Name = "nilma", Salary = 1300 };
            Teacher removeTest2 = new Teacher() { Id = 2, Name = "per", Salary = 1300 };

            repository.AddTeacher(removeTest1);
            repository.AddTeacher(removeTest2);

            repository.Remove(1);
            Assert.AreEqual(1, repository.GetTeachers().Count());

        }

        [TestMethod()]
        public void UpdateTest()
        {
            TeacherRepository repository = new TeacherRepository();
            Teacher teacher1 = new Teacher() { Id = 1, Name = "abe", Salary = 300 };
            Teacher teacher2 = new Teacher() { Id = 2, Name = "koed", Salary = 1300 };
            repository.AddTeacher(teacher1);
            repository.AddTeacher(teacher2);

            Teacher updated = repository.Update(1, teacher2);

            Assert.AreEqual(1, updated?.Id);
            Assert.AreEqual("koed", updated?.Name);
            Assert.AreEqual(1300, updated?.Salary);
        }
    }
}