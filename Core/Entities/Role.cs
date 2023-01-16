using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public sbyte? Deleted { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
