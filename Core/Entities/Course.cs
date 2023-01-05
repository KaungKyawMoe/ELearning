using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class Course
    {
        public Course()
        {
            Classes = new HashSet<Class>();
        }

        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public decimal Fees { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public sbyte Deleted { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
