using Core.Controllers;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Web.Pages.Students
{
    [Authorize]
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
            var _students =  await _studentService.GetAllStudents();
            
            _students.ToList().ForEach(student =>
            {
                if (student.Image != null)
                {
                    student.ImageSrc = "/images/"+ Encoding.UTF8.GetString(student.Image);
                }
            });

            students = _students.ToList();
        }
    }
}
