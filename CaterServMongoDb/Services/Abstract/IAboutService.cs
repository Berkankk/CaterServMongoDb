using CaterServMongoDb.Dtos.AboutDtos;

namespace CaterServMongoDb.Services.Abstract
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GettAllAbouts(); // Tüm hakkımızda alanını liste şeklinde getir

        Task<ResultAboutDto> GetAboutByID(string id);  // id ye göre getirme işlemi

        Task UpdateAbout(UpdateAboutDto updateAbout);

        Task CreateAbout(CreateAboutDto createAbout);

        Task DeleteAbout(string id);
    }
}
