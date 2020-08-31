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

        public IEnumerable<Teacher> Teachers { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public IndexModel(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }

        public void OnGet()
        {
            Teachers = teacherRepository.Search(SearchTerm); 
        }
    }
}
