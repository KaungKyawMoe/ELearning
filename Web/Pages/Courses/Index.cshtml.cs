using Core.Controllers;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

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
            courseDtos.ForEach(x =>
            {
                x.ImageSrc = $"/images/{Encoding.ASCII.GetString(x.Image)}";
            });

            courseList = courseDtos.ToList();
        }
    }
}
