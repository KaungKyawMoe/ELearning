using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Core.Models
{
    public class StudentDto
    {
        public string Id { get; set; } = null!;

        [DisplayName("Enter Name")]
        public string Name { get; set; } = null!;
        public DateTime? Dob { get; set; }
        public string? PhNo { get; set; }
        public string Address { get; set; } = null!;
        public string Nrc { get; set; } = null!;
        public string Email { get; set; } = null!;

        public byte[]? Image { get; set; }

        public string? ImageSrc { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public sbyte? Deleted { get; set; }

        public IFormFile imageFile { get; set; }

        public string UploadedImage { get; set; }
    }
}
