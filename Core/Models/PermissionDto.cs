using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class PermissionDto
    {
        public string Id { get; set; }
        public int MenuId { get; set; }

        public string RoleId { get; set; }

        public string Action { get; set; }
    }
}
