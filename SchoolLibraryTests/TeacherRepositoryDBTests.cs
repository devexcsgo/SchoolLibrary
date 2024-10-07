using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SchoolLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SchoolLibrary.Tests
{
    [TestClass()]
    public class TeacherRepositoryDBTests
    {
        private Mock<TeacherDbContext> _mockContext;
        private TeacherRepositoryDB _repository;
        private List<Teacher> _teachers;

        [TestInitialize]
        public void Setup()
        {
            _teachers = new List<Teacher>
            {
                new Teacher { Id = 1, Name = "John Doe", Salary = 50000 },
                new Teacher { Id = 2, Name = "Jane Smith", Salary = 60000 }
            };

            var mockSet = new Mock<DbSet<Teacher>>();
            mockSet.As<IQueryable<Teacher>>().Setup(m => m.Provider).Returns(_teachers.AsQueryable().Provider);
            mockSet.As<IQueryable<Teacher>>().Setup(m => m.Expression).Returns(_teachers.AsQueryable().Expression);
            mockSet.As<IQueryable<Teacher>>().Setup(m => m.ElementType).Returns(_teachers.AsQueryable().ElementType);
            mockSet.As<IQueryable<Teacher>>().Setup(m => m.GetEnumerator()).Returns(_teachers.AsQueryable().GetEnumerator());

            _mockContext = new Mock<TeacherDbContext>();
            _mockContext.Setup(c => c.Teachers).Returns(mockSet.Object);

            _repository = new TeacherRepositoryDB(_mockContext.Object);
        }

        [TestMethod()]
        public void AddTeacherTest()
        {
            var newTeacher = new Teacher { Name = "New Teacher", Salary = 70000 };
            _repository.AddTeacher(newTeacher);

            _mockContext.Verify(m => m.Teachers.Add(It.IsAny<Teacher>()), Times.Once());
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.AreEqual(0, newTeacher.Id); // Assuming Id is set to 0 before adding
        }

        [TestMethod()]
        public void GetTest()
        {
            var teacher = _repository.Get(1);
            Assert.IsNotNull(teacher);
            Assert.AreEqual("John Doe", teacher.Name);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetTest_TeacherNotFound()
        {
            _repository.Get(999);
        }

        [TestMethod()]
        public void GetTeachersTest()
        {
            var teachers = _repository.GetTeachers(minSalary: 55000);
            Assert.AreEqual(1, teachers.Count);
            Assert.AreEqual("Jane Smith", teachers[0].Name);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            var teacher = _repository.Remove(1);
            Assert.IsNotNull(teacher);
            _mockContext.Verify(m => m.Teachers.Remove(It.IsAny<Teacher>()), Times.Once());
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod()]
        public void RemoveTest_TeacherNotFound()
        {
            var teacher = _repository.Remove(999);
            Assert.IsNull(teacher);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            var updatedTeacher = new Teacher { Name = "Updated Name", Salary = 80000 };
            var teacher = _repository.Update(1, updatedTeacher);

            Assert.IsNotNull(teacher);
            Assert.AreEqual("Updated Name", teacher.Name);
            Assert.AreEqual(80000, teacher.Salary);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod()]
        public void UpdateTest_TeacherNotFound()
        {
            var updatedTeacher = new Teacher { Name = "Updated Name", Salary = 80000 };
            var teacher = _repository.Update(999, updatedTeacher);
            Assert.IsNull(teacher);
        }
    }
}
