using System;
using System.Collections.Generic;
using System.Text;

namespace TeacherDirectory.Models
{
    public class Teacher
    {
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Photopath { get; set; }
        public Dept? Department { get; set; }

    }
}
