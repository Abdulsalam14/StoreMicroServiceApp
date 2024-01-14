namespace ProductService.Services
{
    public interface IProductExtentionService
    {
        Task<string> GetProductImageAsync(int productId);
    }
}
