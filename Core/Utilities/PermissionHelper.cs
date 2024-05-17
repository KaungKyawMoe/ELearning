using Core.Models;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities
{
    public interface IPermissionHelper
    {
        public bool IsAuthorizedUser(string roleId, string menuName, PermissionEnum permission);
    }

    public class PermissionHelper : IPermissionHelper
    {
        private readonly IPermissionService permissionService;
        public PermissionHelper(IPermissionService _permissionService) { 
            permissionService = _permissionService;
        }

        public bool IsAuthorizedUser(string roleId,string menuName,PermissionEnum permission) {
            
            var menuResult = permissionService.GetMenuPermissionByMenuName(menuName).Result;

            if(menuResult != null && menuResult.IsSuccess)
            {
                var menu = menuResult.Data;

                if(menu.RoleId == roleId && menu.Action != null && menu.Action.Contains(permission.ToString().ToLower()))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
