using Core.Controllers;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly ICourseController _courseController;

        public IndexModel(ILogger<IndexModel> logger,
            ICourseController courseController)
        {
            _logger = logger;
            _courseController = courseController;
        }

        public void OnGet()
        {
            
        }
    }
}