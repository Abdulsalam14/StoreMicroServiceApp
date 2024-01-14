using Microsoft.EntityFrameworkCore;
using SearchService.DataContext;
using SearchService.Entities;

namespace SearchService.Repository
{
    public class SearchRepository : ISearchRepository
    {
        private readonly BarcodeContext _context;

        public SearchRepository(BarcodeContext context)
        {
            _context = context;
        }

        public async Task<Barcode> GetAsync(string code)
        {
            var item=await _context.Barcodes.SingleOrDefaultAsync(b => b.Code == code);
            return item;
        }
    }
}
