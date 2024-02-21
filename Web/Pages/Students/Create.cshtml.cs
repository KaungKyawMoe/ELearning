using Core.Controllers;
using Core.Entities;
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
        public StudentDto student { get; set; } = new StudentDto();

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
            ViewData["title"] = id == null ? "Create Student" : "Edit Student";

            if(id != null)
            {
                student = await _studentService.GetStudentById(id);
                if (student.Image != null)
                {
                    student.ImageSrc = "/images/" + Encoding.ASCII.GetString(student.Image);
                }
            }
        }

        public async Task OnPostImageUploadAsync()
        {
            await _appHandler.ImageUpload(student.ImageFile);

            student.UploadedImage = "/images/" + student.ImageFile.FileName;

        }

        public async Task<IActionResult> OnPostAsync()
        {
            ResultModel<object> result = new ResultModel<object>();

            if (student.ImageFile != null)
            {
                var imageSrc = await _appHandler.ImageUpload(student.ImageFile);
                student.Image = Encoding.ASCII.GetBytes(student.ImageFile.FileName);
            }

            if (student.Id != null)
            {
                result = await _studentService.UpdateStudent(student);
            }
            else
            {
                result = await _studentService.CreateStudent(student);
            }

            if (result.IsSuccess)
            {
                return RedirectToPage("/Students/Index");
            }
            else
            {
                ViewData["Message"] = result.Message;
                return Page();
            }
        }
    }
}
