using Core.Controllers;
using Core.Models;
using Core.Services;
using Core.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace Web.Pages.Students
{
    [Authorize]
    public class CreateModel : PageModel
    {
        [BindProperty]
        public StudentDto student { get; set; }

        public string id { get; set; }

        private readonly IStudentService _studentService;
        private readonly IAppHandler _appHandler;

        public CreateModel(IStudentService studentService,
            IAppHandler appHandler)
        {
            _studentService = studentService;
            _appHandler = appHandler;
        }

        public async Task OnGet(String? id = null)
        {
            if(id != null)
            {
                student = await _studentService.GetStudentById(id);
                student.UploadedImage = "/images/" + Encoding.UTF8.GetString(student.Image);
            }
        }

        public async Task OnPostImageUploadAsync()
        {
            await _appHandler.ImageUpload(student.imageFile);

            student.UploadedImage = "/images/" + student.imageFile.FileName;

        }

        public async Task<IActionResult> OnPostAsync()
        {
            var imageFile = await _appHandler.ImageUpload(student.imageFile);

            student.ImageSrc = student.imageFile.FileName;

            if(student.Id != null)
            {
                await _studentService.UpdateStudent(student);
            }
            else
            {
                await _studentService.CreateStudent(student);
            }

            return RedirectToPage("/Students/Index");
        }
    }
}
