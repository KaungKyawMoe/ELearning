using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class RoleDto
    {
        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public sbyte? Deleted { get; set; }
    }
}
