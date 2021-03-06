﻿using System;
using System.Collections.Generic;
using System.Text;
using TeacherDirectory.Models;
using System.Linq;

/*This is just a template used as a DB that isn't connected to this project anymore*/
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
            }; //Contains the fields and data of each field
        }

        public Teacher Add(Teacher newTeacher)
        {
            newTeacher.ID = _teacherList.Max(t => t.ID) + 1;
            _teacherList.Add(newTeacher);
            return newTeacher;
        } //Adding teacher function

        public Teacher Delete(int id)
        {
           Teacher teacherToDelete = _teacherList.FirstOrDefault(t => t.ID == id);

            if (teacherToDelete != null)
            {
                _teacherList.Remove(teacherToDelete);
            } //Remove teacher function

            return teacherToDelete;
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            return _teacherList;
        }

        public Teacher GetTeacher(int id)
        {
            return _teacherList.FirstOrDefault(e => e.ID == id);
        }

        public IEnumerable<Teacher> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return _teacherList;
            }

            return _teacherList.Where(t => t.FName.Contains(searchTerm) || t.Email.Contains(searchTerm));
        } //Searches teachers in this repository

        public IEnumerable<DeptHeadCount> TeacherCountByDept(Dept? dept)
        {
            IEnumerable<Teacher> query = _teacherList;
            if(dept.HasValue)
            {
                query = query.Where(t => t.Department == dept.Value);
            }

            return query.GroupBy(t => t.Department)
                .Select(g => new DeptHeadCount()
                {
                    Department = g.Key.Value,
                    count = g.Count()
                }).ToList();
        } //Head count function in this repository

        public Teacher Update(Teacher updatedTeacher)
        {
            Teacher teacher = _teacherList.FirstOrDefault(t => t.ID == updatedTeacher.ID);

            if(teacher != null)
            {
                teacher.FName = updatedTeacher.FName;
                teacher.Email = updatedTeacher.Email;
                teacher.Department = updatedTeacher.Department;
                teacher.Photopath = updatedTeacher.Photopath;
            }

            return teacher;
        } //Update function in this repository
    }
}
