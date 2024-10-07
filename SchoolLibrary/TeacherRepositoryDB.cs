using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary
{
    public class TeacherRepositoryDB : ITeacherRepository
    {
        private readonly TeacherDbContext _context;

        public TeacherRepositoryDB(TeacherDbContext dbContext)
        {
            _context = dbContext;
        }

        public Teacher AddTeacher(Teacher teacher)
        {
            teacher.Validate();
            teacher.Id = 0;
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
            return teacher;
        }

        public Teacher Get(int id)
        {
            return _context.Teachers.Find(id) ?? throw new InvalidOperationException("Teacher not found");
        }

        public List<Teacher> GetTeachers(int? minSalary = null, string? name = null)
        {
            IQueryable<Teacher> query = _context.Teachers.AsQueryable();
            if (minSalary != null)
            {
                query = query.Where(t => t.Salary > minSalary);
            }
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(t => t.Name.Contains(name));
            }
            return query.ToList();
        }

        public Teacher? Remove(int id)
        {
            Teacher? teacher = _context.Teachers.Find(id);
            if (teacher == null)
            {
                return null;
            }
            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
            return teacher;
        }

        public Teacher? Update(int id, Teacher data)
        {
            data.Validate();
            Teacher? existingTeacher = _context.Teachers.Find(id);
            if (existingTeacher == null)
            {
                return null;
            }
            existingTeacher.Name = data.Name;
            existingTeacher.Salary = data.Salary;
            _context.SaveChanges();
            return existingTeacher;
        }
    }
}
