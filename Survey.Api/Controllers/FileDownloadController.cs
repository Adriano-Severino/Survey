using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Survey.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FileDownloadController : ControllerBase
    {
        [HttpGet("download")]
        [ProducesResponseType(200)]
        public IActionResult DownloadFile(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", fileName);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var contentDisposition = new ContentDisposition
            {
                FileName = fileName,
                Inline = false // Força o download
            };
            Response.Headers.Add("Content-Disposition", contentDisposition.ToString());

            // Defina o tipo MIME apropriado para arquivos .apk
            return PhysicalFile(filePath, "application/vnd.android.package-archive");
        }

    }

}
