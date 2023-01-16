using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class UserDto
    {
        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? RoleId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public sbyte? Deleted { get; set; }

    }

}
