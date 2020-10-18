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

        [BindProperty]
        public Teacher Teacher { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        [BindProperty]
        public bool Notify { get; set; }

        public string Message { get; set; }

        public IActionResult OnGet(int? id)
        {
            if(id.HasValue)
            {
                Teacher = teacherRepository.GetTeacher(id.Value);
            } //If the teacher already exsists in the DB it will allow you to edit the teacher
            else
            {
                Teacher = new Teacher();
            } //If the teacher doesn't exsist it will allow to add a new teacher to the DB

            if(Teacher == null)
            {
                return RedirectToPage("/Error");
            }  //If something unexpected occurs it will send the user to the edit page

            return Page();
        }

        [BindProperty]
        public Teacher teacher { get; set; }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                if (Photo != null)
                {
                    if (Teacher.Photopath != null)
                    {
                        string filePath = Path.Combine(webHostEnvironment.WebRootPath, "images", Teacher.Photopath);
                        System.IO.File.Delete(filePath);
                    }

                    Teacher.Photopath = ProcessUploadedFile();
                }
                
                if (Teacher.ID > 0)
                {
                    Teacher = teacherRepository.Update(Teacher);
                }

                else
                {
                    Teacher = teacherRepository.Add(Teacher);
                }

                return RedirectToPage("Index");
            }

            return Page();
            
        } //Allows the user to add or update the teacher account once it finishes it wil redirect to the home page

        public IActionResult OnPostUpdateNotificationPreferences(int id)
        {
            if (Notify)
            {
                Message = "notifications are turned on";
            }
            else
            {
                Message = "notifications are turned off";
            }

            TempData["message"] = Message;

            return RedirectToPage("Detail", new { id = id,});
        } //these are the notification preferences when the user is creating an account to the teacher DB

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
            } //allows user to add, update or remove a photo from their profile.

            return uniqueFileName;
        }
    }
}
