using BarCodeService.Dtos;
using BarCodeService.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarCodeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarcodeController : ControllerBase
    {
        private readonly IBarcodeRepository _barcodeRepository;

        public BarcodeController(IBarcodeRepository barcodeRepository)
        {
            _barcodeRepository = barcodeRepository;
        }

        [HttpPost("GetBarCode")]
        public async Task<IActionResult> GetBarcode(ProductItemDto dto)
        {
            try
            {
                var code = await _barcodeRepository.AddBarcodeAsync(dto);
                return Ok(new { Data=code });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
