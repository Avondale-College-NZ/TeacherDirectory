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

        [BindProperty(SupportsGet = true)]
        public string Message { get; set; }

        public Teacher Teacher { get; private set; }

        public IActionResult OnGet(int id)
        {
            Teacher = teacherRepository.GetTeacher(id);

            if (Teacher == null) 
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }
    }
}
