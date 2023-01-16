using Core.Controllers;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Courses
{
    [Authorize]
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CourseDto course { get; set; }

        private readonly ICourseService _courseService;

        public CreateModel(ICourseService courseService){
            _courseService = courseService;
        }

        public async Task OnGet()
        {
            course = new CourseDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _courseService.CreateCourse(course);

            return RedirectToPage("/Courses/Index");
        }
    }
}
