using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace TeacherDirectory.Pages.LoginAndRegister
{
    public class LoginModel : PageModel
    {
        [Required(ErrorMessage= "Username is required")]
        [BindProperty]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "password is required"), DataType(DataType.Password)]
        [BindProperty]
        public string Password { get; set; }

        public string Msg { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (Username.Equals("Admin") && Password.Equals("GSOLE"))
            {
                return RedirectToPage("Admin");
            }
            else
            {
                Msg = "Invalid";
                return Page();
            }
        }
    }
}
