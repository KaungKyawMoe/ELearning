using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Index
{
    public class PermissionIndex
    {
        public string Id { get; set; }
        public string MenuName { get; set; }

        public int MenuId { get;set; }

        public string RoleId { get; set; }

        public string RoleName { get; set; }

        public string ParentMenuId { get; set; } = String.Empty;

        public string ParentMenuName { get; set;} = String.Empty;

        public string Action { get; set; }

        public string Permission { get; set; }
    }
}
