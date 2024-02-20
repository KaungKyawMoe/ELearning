using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class Teacher
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public DateTime? Dob { get; set; }

    public string? Nrc { get; set; }

    public string? PhNo { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public byte[]? Image { get; set; }

    public DateTime? JoinedDate { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public sbyte? Deleted { get; set; }
}
