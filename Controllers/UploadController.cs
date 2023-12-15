using Microsoft.AspNetCore.Mvc;

namespace IdentityUserCustom.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UploadController : ControllerBase
    {

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File not selected or empty.");


            // Save the file to a physical path or process it as needed
            var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

            if (!Directory.Exists(uploadDirectory))
            {
                Directory.CreateDirectory(uploadDirectory);
            }

            var filePath = Path.Combine(uploadDirectory, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok("File uploaded successfully!");
        }

    }
}
