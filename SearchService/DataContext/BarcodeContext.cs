using Microsoft.EntityFrameworkCore;
using SearchService.Entities;

namespace SearchService.DataContext
{
    public class BarcodeContext:DbContext
    {
        public BarcodeContext(DbContextOptions<BarcodeContext> options)
            :base(options)
        {
                
        }
        public DbSet<Barcode> Barcodes { get; set; }
    }
}
