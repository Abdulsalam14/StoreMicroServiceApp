using BarCodeService.Entities;
using Microsoft.EntityFrameworkCore;

namespace BarCodeService.DataContext
{
    public class BarCodeContext:DbContext
    {
        public BarCodeContext(DbContextOptions<BarCodeContext> options)
           : base(options)
        {
                
        }
        public DbSet<Barcode> Barcodes { get; set; }
    }
}
