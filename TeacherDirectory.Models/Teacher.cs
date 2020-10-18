using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeacherDirectory.Models
{
    public class Teacher
    {

        public int ID { get; set; }
        [Required(ErrorMessage = "Name is required")] //If nothing is typed the message will pop up 
        [MinLength(3, ErrorMessage = "Name requires at least 3 letters")] //Has to contain 3 letters
        [Display(Name = "First Name")] //Changes the label from FName to First Name
        public string FName { get; set; } //Parameters for the fields
        public string LName { get; set; }
        [Required(ErrorMessage = "Email is required"),]
        [RegularExpression(@"^[a-zA-z0-9_.+-]+@[a-zA-z0-9-]+\.[a-zA-z0-9-.]+$", ErrorMessage = "Invalid Email Format")] //Gives an email format
        [Display(Name = "School Email")]
        public string Email { get; set; }
        public string Photopath { get; set; }
        [Required]
        public Dept? Department { get; set; }
    }
}
