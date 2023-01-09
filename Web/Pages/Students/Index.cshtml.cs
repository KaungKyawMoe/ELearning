using Core.Controllers;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Web.Pages.Students
{
    public class IndexModel : PageModel
    {
        public List<StudentDto> students { get; set; }

        private readonly IStudentController _studentController;

        public IndexModel(IStudentController studentController)
        {
            _studentController = studentController;
        }

        public void OnGet()
        {
            var _students = _studentController.GetAllStudents();
            
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
