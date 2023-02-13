using Core.Controllers;
using Core.Helper;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;

namespace Web.Pages.Auth
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public UserDto User { get; set; }

        [BindProperty]
        public string ErrorMessage { get;set; }

        [BindProperty]
        public List<SelectListItem> Roles{ get;set;}

        private readonly IAuthService _authService;

        private readonly IPasswordHelper _passwordHelper;

        private readonly IConfiguration _configuration;

        private readonly IOptions<Hashing> _hashingOptions;

        public RegisterModel(IAuthService authService,
            IPasswordHelper passwordHelper,
            IConfiguration configuration,
            IOptions<Hashing> hasingOptions)
        {
            _authService = authService;
            _passwordHelper = passwordHelper;
            _configuration = configuration;
            _hashingOptions = hasingOptions;
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

        public async Task<IActionResult> OnPost()
        {
            string hashPassword = this._passwordHelper.HashPassword(User.Password);
            //bool result = this._passwordHelper.VerifyPassword(User.Password, hashPassword);
            User.Password = hashPassword;
            var isUserExist = await _authService.IsUserExist(User);

            if(isUserExist)
            {
                ErrorMessage = "User is already exist on system";
            }
            else
            {
                var result = await _authService.CreateUser(User);
                if (result)
                {
                    return RedirectToPage("/Auth/Login");
                }
            }

            return Page();
        }
    }
}
