using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging.Abstractions;
using TeacherDirectory.Models;
using TeacherDirectory.Services;

namespace TeacherDirectory.Pages.Teachers
{
    public class DeleteModel : PageModel
    {
        private readonly ITeacherRepository teacherRepository;

        public DeleteModel(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }

        [BindProperty]
        public Teacher Teacher { get; set; }
        public IActionResult OnGet(int id)
        {
            Teacher = teacherRepository.GetTeacher(id);

            if (Teacher == null)
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }
        public IActionResult Onpost()
        {
            Teacher deletedTeacher = teacherRepository.Delete(Teacher.ID);

            if(deletedTeacher == null)
            {
                return RedirectToPage("/Error");
            }

            return RedirectToPage("/Teachers/Index");
        }
    }
}
