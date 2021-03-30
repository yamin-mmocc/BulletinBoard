using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BulletinBoardTest.Controllers
{
        public class UploadController : Controller
        {
            private readonly IHostingEnvironment _environment;

            public UploadController(IHostingEnvironment environment)
            {
                _environment = environment;
            }

            [HttpPost, Route("api/upload")]
            public async Task<IActionResult> ImageUpload(IFormFile file)
            {
                var path = Path.Combine(_environment.WebRootPath, @"images\upload");

                //var fileName = file.Filename;
                var fileFullName = file.FileName.Split('.');
                var fileName = $"{Guid.NewGuid()}.{fileFullName[1]}";

                using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                return Ok(new { file = "/images/upload/" + fileName, success = true });
            }
        }
}
