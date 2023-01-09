using Core.Controllers;
using Core.Models;
using Core.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace Web.Pages.Students
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public StudentDto student { get; set; }

        public string id { get; set; }

        private readonly IStudentController _studentController;
        private readonly IAppHandler _appHandler;

        public CreateModel(IStudentController studentController,
            IAppHandler appHandler)
        {
            _studentController = studentController;
            _appHandler = appHandler;
        }

        public void OnGet(String? id = null)
        {
            if(id != null)
            {
                student = _studentController.GetStudentById(id);
                student.UploadedImage = "/images/" + Encoding.UTF8.GetString(student.Image);
            }
        }

        public async Task OnPostImageUploadAsync()
        {
            await _appHandler.ImageUpload(student.imageFile);

            student.UploadedImage = "/images/" + student.imageFile.FileName;

        }

        public async  Task<IActionResult> OnPostAsync()
        {
            var imageFile = await _appHandler.ImageUpload(student.imageFile);

            student.ImageSrc = student.imageFile.FileName;

            if(student.Id != null)
            {
                _studentController.Update(student);
            }
            else
            {
                _studentController.Create(student);
            }

            return RedirectToPage("/Students/Index");
        }
    }
}
