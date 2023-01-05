using Core.Controllers;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly ICourseController _courseController;


        public List<CourseDto> courseList;

        public IndexModel(ICourseController courseController)
        {
            _courseController = courseController;
        }

        public void OnGet()
        {
            var courseDtos = _courseController.GetCourses();
            courseList = courseDtos.ToList();
        }
    }
}
