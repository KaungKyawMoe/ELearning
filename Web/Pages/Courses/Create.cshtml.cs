using Core.Controllers;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Courses
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CourseDto course { get; set; }

        private readonly ICourseController _courseController;

        public CreateModel(ICourseController courseController){
            _courseController= courseController;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _courseController.CreateCourse(course);

            return RedirectToPage("/Courses/Index");
        }
    }
}
