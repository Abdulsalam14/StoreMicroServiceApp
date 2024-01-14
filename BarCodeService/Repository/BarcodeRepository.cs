using BarCodeService.DataContext;
using BarCodeService.Dtos;
using BarCodeService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BarCodeService.Repository
{
    public class BarcodeRepository : IBarcodeRepository
    {
        private readonly BarCodeContext _context;

        public BarcodeRepository(BarCodeContext context)
        {
            _context = context;
        }

        public async Task<string> AddBarcodeAsync(ProductItemDto productItemDto)
        {
            var item = await _context.Barcodes.FirstOrDefaultAsync(b => b.ProductId == productItemDto.ProductId && b.Volume == productItemDto.Volume);
            if (item == null)
            {
                var data = new Barcode
                {
                    Code = $"4-12345:{productItemDto.ProductId}-{productItemDto.Volume}",
                    ProductName = productItemDto.ProductName,
                    ProductId = productItemDto.ProductId,
                    Volume = productItemDto.Volume,
                    TotalPrice = productItemDto.Volume * productItemDto.Price
                };
                await _context.Barcodes.AddAsync(data);
                await _context.SaveChangesAsync();
                return data.Code;
            }
            return item.Code;
        }
    }
}
