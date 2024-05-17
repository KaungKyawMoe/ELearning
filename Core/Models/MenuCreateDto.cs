using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class MenuCreateDto
    {
        public string Id { get; set; } = null!;

        public string? Name { get; set; }

        public string? ParentMenuId { get; set; }

        public sbyte? Sort { get; set; }

        public string? Link { get; set; }

        public string? Icon { get; set; }
    }
}
