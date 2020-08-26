using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeacherDirectory.Models;
using TeacherDirectory.Services;

namespace TeacherDirectory.Pages.Teachers
{
    public class EditModel : PageModel
    {
        private readonly ITeacherRepository teacherRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        public EditModel(ITeacherRepository teacherRepository, IWebHostEnvironment webHostEnvironment)
        {
            this.teacherRepository = teacherRepository;
            this.webHostEnvironment = webHostEnvironment;
        }

        public Teacher Teacher { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        public IActionResult OnGet(int id)
        {
            Teacher = teacherRepository.GetTeacher(id);

            if(Teacher == null)
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }

        [BindProperty]
        public Teacher teacher { get; set; }

        public IActionResult OnPost()
        {
            if(Photo != null)
            {
                if (teacher.Photopath != null)
                {
                    string filePath = Path.Combine(webHostEnvironment.WebRootPath, "images", teacher.Photopath);
                    System.IO.File.Delete(filePath);
                }
                teacher.Photopath = ProcessUploadedFile();
            }
            
            Teacher = teacherRepository.Update(teacher);
            return RedirectToPage("Index");
        }
        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;

            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
