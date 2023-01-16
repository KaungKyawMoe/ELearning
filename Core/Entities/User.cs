using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class User
    {
        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? RoleId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public sbyte? Deleted { get; set; }

        public virtual Role? Role { get; set; }
    }
}
