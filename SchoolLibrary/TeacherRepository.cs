using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary
{
    public class TeacherRepository : Teacher
    {
        private int nextId = 1;
        protected List<Teacher> teachers = new List<Teacher>();

        public void AddTeacher(Teacher teacher)
        {
            teacher.Validate();
            teacher.Id = nextId++;
            teachers.Add(teacher);
        }

        public List<Teacher> GetTeachers(int? minSalary = null, string? name=null)
        {
            List<Teacher> result = new List<Teacher>(teachers);
            if (minSalary != null )
            {
                       result = result.Where(t => t.Salary >= minSalary).ToList();
     
            }
            if (name != null) 
            {
            result = result.FindAll(t => t.Name == name);
            }
            return result;
        }

        public Teacher? Get(int id)
        {
            return teachers.FirstOrDefault(t => t.Id == id);
        }

        public Teacher? Remove(int id)
        {
            Teacher? teacher = Get(id);
            if (teacher == null)
            {
                return null;
            }
            teachers.Remove(teacher);
            return teacher;
        }

        public Teacher? Update(int id, Teacher data)
        {
            data.Validate();
            Teacher? exsistingTeacher = Get(id);
            if (exsistingTeacher == null)
            {
                return null;
            }
            exsistingTeacher.Name = data.Name;
            exsistingTeacher.Salary = data.Salary;
            return exsistingTeacher;
        }


    }
}
