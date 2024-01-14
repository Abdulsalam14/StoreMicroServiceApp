using LogService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogService _logService;

        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpPost("AddLog")]
        public async Task<IActionResult> Add([FromBody]string logMessage)
        {

            if (string.IsNullOrWhiteSpace(logMessage))
            {
                return BadRequest();
            }

            try
            {
                await _logService.Append(logMessage);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}

