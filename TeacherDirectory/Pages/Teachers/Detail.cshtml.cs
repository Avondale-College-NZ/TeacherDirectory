using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeacherDirectory.Models;
using TeacherDirectory.Services;

namespace TeacherDirectory.Pages.Teachers
{
    public class DetailModel : PageModel
    {
        private readonly ITeacherRepository teacherRepository;
        public DetailModel(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }

        public Teacher Teacher { get; private set; }

        public void OnGet(int id)
        {
            Teacher = teacherRepository.GetTeacher(id);
        }
    }
}
