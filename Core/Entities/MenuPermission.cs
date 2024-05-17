using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class MenuPermission
{
    public string Id { get; set; } = null!;

    public int? MenuId { get; set; }

    public string? RoleId { get; set; }

    public string? Action { get; set; }

    public virtual Menu? Menu { get; set; }

    public virtual Role? Role { get; set; }
}
