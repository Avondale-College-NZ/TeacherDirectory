using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TeacherDirectory.Pages.Login
{
    public class IndexModel : PageModel
    {
        public string Username { get; set; }

        public void Onget()
        {
        }

        public IActionResult OnGetLogout()
        {
            return RedirectToPage("Index");
        }
    }
}
