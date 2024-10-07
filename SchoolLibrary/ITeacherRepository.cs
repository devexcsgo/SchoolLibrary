
namespace SchoolLibrary
{
    public interface ITeacherRepository
    {
        Teacher AddTeacher(Teacher teacher);
        Teacher? Get(int id);
        List<Teacher> GetTeachers(int? minSalary = null, string? name = null);
        Teacher? Remove(int id);
        Teacher? Update(int id, Teacher data);
    }
}