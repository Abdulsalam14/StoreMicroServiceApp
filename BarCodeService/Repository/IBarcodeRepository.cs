using BarCodeService.Dtos;

namespace BarCodeService.Repository
{
    public interface IBarcodeRepository
    {
        Task<string> AddBarcodeAsync(ProductItemDto productItemDto);
    }
}
