namespace CaterServMongoDb.Services.Abstract
{
    public interface IImageService
    {
        Task<string> CreateImage(IFormFile file);
    }
}
