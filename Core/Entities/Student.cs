using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class Student
    {
        public Student()
        {
            Classes = new HashSet<Class>();
        }

        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public DateTime? Dob { get; set; }
        public string? PhNo { get; set; }
        public string Address { get; set; } = null!;
        public string Nrc { get; set; } = null!;
        public string Email { get; set; } = null!;
        public byte[]? Image { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public sbyte? Deleted { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
