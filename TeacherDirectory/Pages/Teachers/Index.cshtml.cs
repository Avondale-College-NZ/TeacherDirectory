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
    public class IndexModel : PageModel
    {
        private readonly ITeacherRepository teacherRepository;

        public IEnumerable<Teacher> Teachers { get; set; } //Ienumerable is a an interface that can define a single method

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public IndexModel(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }

        public void OnGet()
        {
            Teachers = teacherRepository.Search(SearchTerm); 
        } //Allows users to use a search bar that looks for teachers in the teacher DB
    }
}
