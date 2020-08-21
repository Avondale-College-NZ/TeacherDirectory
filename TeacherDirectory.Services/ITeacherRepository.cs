using System;
using System.Collections.Generic;
using TeacherDirectory.Models;

namespace TeacherDirectory.Services
{
    public interface ITeacherRepository
    {
        IEnumerable<Teacher> GetAllTeachers();
    }
}
