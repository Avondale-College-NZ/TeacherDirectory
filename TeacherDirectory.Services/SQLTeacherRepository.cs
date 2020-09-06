using System;
using System.Collections.Generic;
using System.Text;
using TeacherDirectory.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace TeacherDirectory.Services
{
    public class SQLTeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext context;

        public SQLTeacherRepository(AppDbContext context)
        {
            this.context = context;
        }
        
        public Teacher Add(Teacher newTeacher)
        {
            context.Teachers.Add(newTeacher);
            context.SaveChanges();
            return newTeacher;
        }

        public Teacher Delete(int id)
        {
            Teacher teacher = context.Teachers.Find(id);
            if(teacher != null)
            {
                context.Teachers.Remove(teacher);
                context.SaveChanges();
            }
            return teacher;
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            return context.Teachers.FromSqlRaw<Teacher>("SELECT * FROM teachers").ToList();
        }

        public Teacher GetTeacher(int id)
        {
            SqlParameter parameter = new SqlParameter("@Id", id);
            
            return context.Teachers.FromSqlRaw<Teacher>("spGetTeacherById @Id", parameter).ToList().FirstOrDefault();
        }

        public IEnumerable<Teacher> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return context.Teachers;
            }

            return context.Teachers.Where(t => t.FName.Contains(searchTerm) || t.Email.Contains(searchTerm));
        }

        public IEnumerable<DeptHeadCount> TeacherCountByDept(Dept? dept)
        {
            IEnumerable<Teacher> query = context.Teachers;
            if (dept.HasValue)
            {
                query = query.Where(t => t.Department == dept.Value);
            }

            return query.GroupBy(t => t.Department)
                .Select(g => new DeptHeadCount()
                {
                    Department = g.Key.Value,
                    count = g.Count()
                }).ToList();
        }

        public Teacher Update(Teacher updatedTeacher)
        {
            var teacher = context.Teachers.Attach(updatedTeacher);
            teacher.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updatedTeacher;
        }
    }
}
