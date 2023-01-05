using Core.Controllers;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Web.Pages.Courses
{
    public class EditModel : PageModel
    {

        ICourseController _courseController;

        [BindProperty]
        public CourseDto course { get; set; }

        public EditModel(ICourseController courseController)
        {
            _courseController = courseController;
        }

        public void OnGet(String? Id)
        {
            var _course = _courseController.GetCourse(Id);
            if(_course != null)
            {
                course = _course;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _courseController.UpdateCourse(course);

            return RedirectToPage("./Index");
        }
    }
}
