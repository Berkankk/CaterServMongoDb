using CaterServMongoDb.Dtos.CheffDtos;

namespace CaterServMongoDb.Services.Abstract
{
    public interface ICheffService
    {
        Task<List<ResultCheffDto>> GetAllCheffs(); //Tüm şefleri bana liste olarak ver
        Task<ResultCheffDto> GetCheffById(string id); //Şefleri bana idsine göre ver
        Task UpdateCheff(UpdateCheffDto updateCheff);
        Task CreateCheff(CreateCheffDto createCheff);
        Task DeleteCheff(string id); //idsine göre sil
    }
}
