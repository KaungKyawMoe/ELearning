using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities
{
    public interface IAppHandler
    {
        public Task<string> ImageUpload(IFormFile uploadFile);
    }

    public class AppHandler : IAppHandler
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public AppHandler(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<string> ImageUpload(IFormFile uploadFile)
        {
            var file = Path.Combine(_hostingEnvironment.WebRootPath, "images", uploadFile.FileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await uploadFile.CopyToAsync(fileStream);
            }

            var imageFile = Path.Combine("images",uploadFile.FileName);

            return imageFile;
        }
    }
}
