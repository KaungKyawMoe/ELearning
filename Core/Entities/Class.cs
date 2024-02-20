using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class Class
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string CourseId { get; set; } = null!;

    public string StudentId { get; set; } = null!;

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public sbyte Deleted { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
