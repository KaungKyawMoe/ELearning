using Core.Controllers;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Web.Pages.Courses
{
    [Authorize]
    public class EditModel : PageModel
    {

        ICourseService _couserService;

        [BindProperty]
        public CourseDto course { get; set; }

        public EditModel(ICourseService courseService)
        {
            _couserService = courseService;
        }

        public async Task OnGet(String? Id)
        {
            var _course = await _couserService.GetCourse(Id);
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

            await _couserService.UpdateCourse(course);

            return RedirectToPage("./Index");
        }
    }
}
