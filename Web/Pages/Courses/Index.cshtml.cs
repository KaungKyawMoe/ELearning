using Core.Controllers;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Courses
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ICourseService _courseService;


        public List<CourseDto> courseList;

        public IndexModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task OnGet()
        {
            var courseDtos = await _courseService.GetCourses();
            courseList = courseDtos.ToList();
        }
    }
}
