using System;
using System.Collections.Generic;
using TeacherDirectory.Models;

namespace TeacherDirectory.Services
{
    public interface ITeacherRepository
    {
        IEnumerable<Teacher> Search(string searchTerm);
        IEnumerable<Teacher> GetAllTeachers();
        Teacher GetTeacher(int id);
        Teacher Update(Teacher updatedTeacher);
        Teacher Add(Teacher newTeacher);
        Teacher Delete(int id);
        IEnumerable<DeptHeadCount> TeacherCountByDept(Dept? dept);
    }
}
