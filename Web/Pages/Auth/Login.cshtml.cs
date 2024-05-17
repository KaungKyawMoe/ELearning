using Core.Helper;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Web.Pages.Auth
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public UserDto user { get; set; }

        private readonly IAuthService _authService;
        public readonly IPasswordHelper _passwordHelper;
        public LoginModel(IAuthService authService,
            IPasswordHelper passwordHelper)
        {
            _authService = authService;
            _passwordHelper = passwordHelper;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            var userInfo = await _authService.GetUserByEmail(user.Email);

            if (userInfo == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }
            else
            {
                if (_passwordHelper.VerifyPassword(user.Password ?? "", userInfo.Password))
                {
                    var role = await _authService.GetRoleById(userInfo.RoleId);

                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, userInfo.Name ?? ""),
                        new Claim(ClaimTypes.Role, role.Name ?? ""),
                        new Claim("RoleId",role.Id ?? "")
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        //AllowRefresh = <bool>,
                        // Refreshing the authentication session should be allowed.

                        //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                        // The time at which the authentication ticket expires. A 
                        // value set here overrides the ExpireTimeSpan option of 
                        // CookieAuthenticationOptions set with AddCookie.

                        //IsPersistent = true,
                        // Whether the authentication session is persisted across 
                        // multiple requests. When used with cookies, controls
                        // whether the cookie's lifetime is absolute (matching the
                        // lifetime of the authentication ticket) or session-based.

                        //IssuedUtc = <DateTimeOffset>,
                        // The time at which the authentication ticket was issued.

                        //RedirectUri = <string>
                        // The full path or absolute URI to be used as an http 
                        // redirect response value.
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    return RedirectToPage("/Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            return Page();
        }
    }
}
