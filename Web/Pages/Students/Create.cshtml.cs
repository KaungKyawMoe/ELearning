using Core.Controllers;
using Core.Models;
using Core.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Students
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public StudentDto student { get; set; }

        [BindProperty]
        public IFormFile image { get; set; }

        private readonly IStudentController _studentController;
        private readonly IAppHandler _appHandler;

        public CreateModel(IStudentController studentController,
            IAppHandler appHandler)
        {
            _studentController = studentController;
            _appHandler = appHandler;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var imageFile = await _appHandler.ImageUpload(image);

            student.ImageSrc = image.FileName;

            _studentController.Create(student);

            return RedirectToPage("/Students/Index");
        }
    }
}
