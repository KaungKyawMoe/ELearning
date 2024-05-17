using Core.Models;
using Core.Models.Index;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Web.Pages.PermissionManagement
{
    public class IndexModel : PageModel
    {
        public IList<PermissionIndex> permissions { get; set; } = new List<PermissionIndex>();
        private readonly IPermissionService permissionService;

        public IndexModel(IPermissionService _permissionService)
        {
            permissionService = _permissionService;
            permissions = new List<PermissionIndex>();
        }
        public async Task OnGet()
        {
            
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            var data = await permissionService.GetList();
            string[] actions = Enum.GetValues(typeof(PermissionEnum)).Cast<PermissionEnum>().Select(x=>x.ToString().ToLower()).ToArray();
            data.ForEach(x =>
            {
                var checkBox = "";
                foreach (var action in actions)
                {
                    checkBox += $"<div class='form-check form-check-inline'>";
                    if (x.Action.ToLower().Contains(action))
                    {
                        checkBox += $"<input class='form-check-input' type='checkbox' name='chkPermission' checked data-id='{x.Id}' value='{action}'/> {action} &nbsp;";
                    }
                    else
                    {
                        checkBox += $"<input class='form-check-input' type='checkbox' name='chkPermission' data-id='{x.Id}' value='{action}'/> {action} &nbsp;";
                    }
                    checkBox += "</div>";
                }

                x.Permission = checkBox;
            });

            permissions = data;
            return new JsonResult(permissions);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostUpdateDataAsync(PermissionDto data)
        {
            var requestData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PermissionDto>>(Request.Form["model"]);
            var result = await permissionService.UpdatePermission(requestData);
            return new JsonResult(result);
        }
    }
}
