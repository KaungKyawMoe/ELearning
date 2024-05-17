using Core.Controllers;
using Core.Models;
using Core.Services;
using Core.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace Web.Pages.Courses
{
    [Authorize]
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CourseDto course { get; set; } = new CourseDto();

        private readonly ICourseService _courseService;
        private readonly IAppHandler _appHandler;
        private readonly IPermissionHelper _permissionHelper;

        public CreateModel(ICourseService courseService,
            IAppHandler appHandler,
            IPermissionHelper permissionHelper)
        {
            _courseService = courseService;
            _appHandler = appHandler;
            _permissionHelper = permissionHelper;
        }

        public async Task<IActionResult> OnGet(String? id = null)
        {
            string roleId = Request.HttpContext.User.Claims.First(x => x.Type == "RoleId").Value.ToString();

            if(!_permissionHelper.IsAuthorizedUser(roleId, "course", PermissionEnum.Create))
            {
                return RedirectToPage("/Courses/Index");
            }

            ViewData["title"] = id == null ? "Create Course" : "Edit Course";

            if (id != null)
            {
                course = await _courseService.GetCourse(id);

                if(course.Image != null)
                {
                    course.ImageSrc = "/images/"+Encoding.ASCII.GetString(course.Image);
                }
            }
            //course = new CourseDto();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                ResultModel<object> result = new ResultModel<object>();

                if (course.ImageFile != null)
                {
                    var imageSrc = await _appHandler.ImageUpload(course.ImageFile);
                    course.Image = Encoding.ASCII.GetBytes(course.ImageFile.FileName);
                }

                if (course != null && course.Id != null)
                {
                    result = await _courseService.UpdateCourse(course);
                }
                else
                {
                    result = await _courseService.CreateCourse(course);
                }

                if (!result.IsSuccess)
                {
                    ViewData["Message"] = result.Message;
                    return Page();
                }
            }
            catch(Exception ex)
            {
                ViewData["Message"] = ex.Message;
                return Page();
            }

            return RedirectToPage("/Courses/Index");
        }
    }
}
