using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class Menu
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? ParentMenuId { get; set; }

    public sbyte? Sort { get; set; }

    public string? Link { get; set; }

    public string? Icon { get; set; }

    public ulong? Deleted { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual ICollection<MenuPermission> MenuPermissions { get; set; } = new List<MenuPermission>();
}
