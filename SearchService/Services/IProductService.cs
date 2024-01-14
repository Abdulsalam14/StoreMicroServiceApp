namespace SearchService.Services
{
    public interface IProductService
    {
        Task<string> GetProductImagePathAsync(int productId);    
    }
}
