using CaterServMongoDb.Dtos.ServiceDtos;

namespace CaterServMongoDb.Services.Abstract
{
    public interface IServiceService
    {
        Task<List<ResultServiceDto>> GetAllServices();
        Task<ResultServiceDto> GetServiceById(string id);
        Task UpdateService(UpdateServiceDto serviceDto);
        Task CreateService(CreateServiceDto serviceDto);
        Task DeleteService(string id);
    }
}
