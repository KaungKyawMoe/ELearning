using Core.Controllers;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Pages.Auth
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public UserDto User { get; set; }

        [BindProperty]
        public List<SelectListItem> Roles{ get;set;}

        private readonly IAuthService _authService;
        public RegisterModel(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task OnGet()
        {
           var data = await _authService.GetAllRoles();

           Roles = data.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id
            }).ToList();
        }

        public void OnPost()
        {

        }
    }
}
