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
        private readonly ITeacherRepository teacherRepository; //This interface teacher repository is within the Teacher.Services class

        public DeleteModel(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }

        [BindProperty]
        public Teacher Teacher { get; set; }
        public IActionResult OnGet(int id)
        {
            Teacher = teacherRepository.GetTeacher(id); //gets teacher from the teacher DB

            if (Teacher == null)
            {
                return RedirectToPage("/Error");
            } //If the teacher isn't there it will redirect to the error page.

            return Page();
        }
        public IActionResult Onpost()
        {
            Teacher deletedTeacher = teacherRepository.Delete(Teacher.ID); //Deletes teacher from the teacher DB

            if(deletedTeacher == null)
            {
                return RedirectToPage("/Error");
            }

            return RedirectToPage("/Teachers/Index"); //Once the code is done it returns the user to the teachers page
        }
    }
}
