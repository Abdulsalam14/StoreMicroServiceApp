using ImageServiceApi.Dtos;

namespace ImageServiceApi.Services
{
    public interface IPhotoService
    {
        Task<string> UploadImageAsync(PhotoCreationDto dto);
    }
}
