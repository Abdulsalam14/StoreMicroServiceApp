using ImageServiceApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private IPhotoService _photoService;

        public ImageController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var file = Request.Form.Files.GetFile("file");
            if (file != null && file.Length > 0)
            {
                string result = await _photoService.UploadImageAsync(new Dtos.PhotoCreationDto { File = file });

                return Ok(result);
            }
            return BadRequest(new { message = "No File Received" });
        }
    }
}
