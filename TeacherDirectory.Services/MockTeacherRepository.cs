using System;
using System.Collections.Generic;
using System.Text;
using TeacherDirectory.Models;

namespace TeacherDirectory.Services
{
    public class MockTeacherRepository : ITeacherRepository
    {
        private List<Teacher> _teacherList;
        
        public MockTeacherRepository()
        {
            _teacherList = new List<Teacher>()
            {
                new Teacher() { ID = 1, FName = "Shayen", LName = "Kesha", Email = "ac98811@avcol.school.nz", Department = Dept.Science, Photopath = ""},
                new Teacher() { ID = 2, FName = "Cooper", LName = "Hiebendal", Email = "", Department = Dept.SocialScience, Photopath = ""},
                new Teacher() { ID = 3, FName = "Malhar", LName = "Gohel", Email = "", Department = Dept.Math, Photopath = ""},
                new Teacher() { ID = 4, FName = "Aziz", LName = "Patel", Email = "", Department = Dept.Technology, Photopath = ""},
            };
        }
        
        public IEnumerable<Teacher> GetAllTeachers()
        {
            return _teacherList;
        }
    }
}
