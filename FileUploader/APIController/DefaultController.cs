using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploader.APIController
{
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [Route("api/get")]
        public IActionResult GetCount()
        {
            return Ok(new { count = 0 });
        }

        [Route("api/upload/{id}")]
        [HttpPost]
        public async Task<IActionResult> Post(string id)
        {
            IEnumerable<string> headerValues = Request.Headers["Authorization"];
            var header = headerValues.FirstOrDefault();
            var xcust  = Request.Headers["xcust"];
            var filePath = @"D:\Workshop\" + id; //+ Guid.NewGuid() + ".png";
            if (Request.HasFormContentType)
            {
                var form = Request.Form;
                foreach (var formFile in form.Files)
                {
                    if (formFile.Length > 0)
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                    }
                }
            }
            return Ok(new { Path = filePath });
        }
    }
}