using AutoMapper;
using CaterServMongoDb.DataAccess.Entities;
using CaterServMongoDb.Dtos.ServiceDtos;
using CaterServMongoDb.Services.Abstract;
using CaterServMongoDb.Settings;
using MongoDB.Driver;

namespace CaterServMongoDb.Services.Concrete
{
    public class ServiceService : IServiceService
    {
        private readonly IMongoCollection<Service> _serviceCollecion;
        private readonly IMapper _mapper;

        public ServiceService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var dataBase = client.GetDatabase(databaseSettings.DatabaseName);
            _serviceCollecion = dataBase.GetCollection<Service>(databaseSettings.ServiceCollectionName);
            _mapper = mapper;
        }

        public async Task CreateService(CreateServiceDto serviceDto)
        {
            var value = _mapper.Map<Service>(serviceDto);
            await _serviceCollecion.InsertOneAsync(value);
        }

        public async Task DeleteService(string id)
        {
            await _serviceCollecion.DeleteOneAsync(x => x.ServiceID == id);
        }

        public async Task<List<ResultServiceDto>> GetAllServices()
        {
            var value = await _serviceCollecion.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultServiceDto>>(value);
        }

        public async Task<ResultServiceDto> GetServiceById(string id)
        {
            var value = await _serviceCollecion.Find(x => x.ServiceID == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultServiceDto>(value);
        }

        public async Task UpdateService(UpdateServiceDto serviceDto)
        {
            var value = _mapper.Map<Service>(serviceDto);
            await _serviceCollecion.FindOneAndReplaceAsync(x => x.ServiceID == value.ServiceID, value);
        }
    }
}
