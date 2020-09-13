using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TeacherDirectory.Pages.LoginAndRegister
{
    public class IndexModel : PageModel
    {
        [Required]
        [EmailAddressAttribute]
        public string Email { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string Username { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string Password { get; set; }

        [Required]
        public string Department { get; set; }
    }
}
