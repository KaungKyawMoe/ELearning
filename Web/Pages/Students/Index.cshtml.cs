using Core.Controllers;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;

namespace Web.Pages.Students
{
    //[Authorize]
    public class IndexModel : PageModel
    {
        public List<StudentDto> students { get; set; }

        private readonly IStudentService _studentService;

        public IndexModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task OnGet()
        {
            //var _students =  await _studentService.GetAllStudents();
            
            //_students.ToList().ForEach(student =>
            //{
            //    if (student.Image != null)
            //    {
            //        student.ImageSrc = "/images/"+ Encoding.UTF8.GetString(student.Image);
            //    }
            //});

            students = new List<StudentDto>();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPost()
        {
            var _students = await _studentService.GetAllStudents();

            _students.ToList().ForEach(student =>
            {
                if (student.Image != null)
                {
                    student.ImageSrc = "/images/" + Encoding.UTF8.GetString(student.Image);
                }
            });

            students = _students.ToList();
            return new JsonResult(students);
            
        }
    }
}
