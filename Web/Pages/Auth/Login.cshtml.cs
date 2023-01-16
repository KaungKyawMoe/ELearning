using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Auth
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public UserDto user { get; set; }
        public void OnGet()
        {
        }
    }
}
