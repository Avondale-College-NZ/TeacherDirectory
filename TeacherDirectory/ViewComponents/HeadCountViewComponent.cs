using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherDirectory.Models;
using TeacherDirectory.Services;

namespace TeacherDirectory.ViewComponents
{
    public class HeadCountViewComponent : ViewComponent
    {
        private readonly ITeacherRepository teacherRepository;

        public HeadCountViewComponent(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }

        public IViewComponentResult Invoke(Dept? departmentName = null)
        {
            var result = teacherRepository.TeacherCountByDept(departmentName);
            return View(result);
        }
    }
}
