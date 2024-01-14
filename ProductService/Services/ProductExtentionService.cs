using ProductService.Repository;

namespace ProductService.Services
{
    public class ProductExtentionService : IProductExtentionService
    {
        private readonly IProductRepository _productRepository;

        public ProductExtentionService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<string> GetProductImageAsync(int productId)
        {
            var item=await _productRepository.GetByID(productId);
            return item != null ? item.ImageUrl : "";
        }
    }
}
