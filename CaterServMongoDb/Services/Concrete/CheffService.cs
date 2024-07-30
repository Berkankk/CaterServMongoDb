using AutoMapper;
using CaterServMongoDb.DataAccess.Entities;
using CaterServMongoDb.Dtos.CheffDtos;
using CaterServMongoDb.Services.Abstract;
using CaterServMongoDb.Settings;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MongoDB.Driver;

namespace CaterServMongoDb.Services.Concrete
{
    public class CheffService : ICheffService
    {
        private readonly IMongoCollection<Cheff> _cheffCollection;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public CheffService(IMapper mapper, IDatabaseSettings databaseSettings, IImageService imageService)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _cheffCollection = database.GetCollection<Cheff>(databaseSettings.CheffCollectionName);
            _mapper = mapper;
            _imageService = imageService;
        }

        public async Task CreateCheff(CreateCheffDto createCheff)
        {
            var ImageUrl = await _imageService.CreateImage(createCheff.File);
            createCheff.ImageUrl = ImageUrl;

            var value = _mapper.Map<Cheff>(createCheff);
            await _cheffCollection.InsertOneAsync(value);
        }

        public async Task DeleteCheff(string id)
        {
            await _cheffCollection.DeleteOneAsync(x => x.CheffID == id);
        }

        public async Task<List<ResultCheffDto>> GetAllCheffs()
        {
            var value = await _cheffCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultCheffDto>>(value);
        }

        public async Task<ResultCheffDto> GetCheffById(string id)
        {
            var value = await _cheffCollection.Find(x => x.CheffID == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultCheffDto>(value);
        }

        public async Task UpdateCheff(UpdateCheffDto updateCheff)
        {
            var ImageUrl = await _imageService.CreateImage(updateCheff.File);
            updateCheff.ImageUrl = ImageUrl;

            var value = _mapper.Map<Cheff>(updateCheff);
            await _cheffCollection.FindOneAndReplaceAsync(x => x.CheffID == updateCheff.CheffID, value);
        }
    }
}
