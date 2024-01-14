using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SearchService.Dtos;
using SearchService.Repository;
using SearchService.Services;

namespace SearchService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private ISearchRepository _searchRepository;
        private IProductService _productService;

        public SearchController(ISearchRepository searchRepository, IProductService productService)
        {
            _searchRepository = searchRepository;
            _productService = productService;
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> Get(string code)
        {
            try
            {
                var item = await _searchRepository.GetAsync(code);
                if (item == null)
                {
                    return NotFound();
                }

                var dto = new BarcodeDto
                {
                    Code=item.Code,
                     ProductName=item.ProductName,
                      TotalPrice=item.TotalPrice,
                       Volume=item.Volume,
                        Id=item.Id,
                };

                var productId = item.ProductId;
                var result=await _productService.GetProductImagePathAsync(productId);
                dto.ImageUrl = result;

                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
