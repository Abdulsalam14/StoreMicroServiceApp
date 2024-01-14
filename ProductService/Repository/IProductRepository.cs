using ProductService.Entities;

namespace ProductService.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();   
        Task<Product> GetByID(int id);      
        Task AddProduct(Product product);       
        Task Update(Product product);       
    }
}
