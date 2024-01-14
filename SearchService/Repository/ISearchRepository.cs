using SearchService.Entities;

namespace SearchService.Repository
{
    public interface ISearchRepository
    {
        Task<Barcode> GetAsync(string code);
    }
}
