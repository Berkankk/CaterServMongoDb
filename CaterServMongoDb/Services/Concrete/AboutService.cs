using AutoMapper;
using CaterServMongoDb.DataAccess.Entities;
using CaterServMongoDb.Dtos.AboutDtos;
using CaterServMongoDb.Dtos.CategoryDtos;
using CaterServMongoDb.Services.Abstract;
using CaterServMongoDb.Settings;
using MongoDB.Driver;
using ZstdSharp.Unsafe;

namespace CaterServMongoDb.Services.Concrete
{
    public class AboutService : IAboutService
    {
        private readonly IMongoCollection<About> _aboutCollection;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;


        public AboutService(IMapper mapper, IDatabaseSettings databaseSettings, IImageService imageService)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _aboutCollection = database.GetCollection<About>(databaseSettings.AboutCollectionName);
            _mapper = mapper;
            _imageService = imageService;
        }

        public async Task CreateAbout(CreateAboutDto createAbout)
        {
            var ImageUrl = await _imageService.CreateImage(createAbout.File);
            createAbout.ImageUrl = ImageUrl;

            var value = _mapper.Map<About>(createAbout);
            await _aboutCollection.InsertOneAsync(value);
        }

        public async Task DeleteAbout(string id)
        {
            await _aboutCollection.DeleteOneAsync(x => x.AboutID == id);

        }

        public async Task<ResultAboutDto> GetAboutByID(string id)
        {
            var value = await _aboutCollection.Find(x => x.AboutID == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultAboutDto>(value);
        }

        public async Task<List<ResultAboutDto>> GettAllAbouts()
        {
            var value = await _aboutCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultAboutDto>>(value);
        }

        public Task UpdateAbout(UpdateAboutDto updateAbout)
        {
            var value = _mapper.Map<About>(updateAbout);
            return _aboutCollection.FindOneAndReplaceAsync(x => x.AboutID == value.AboutID, value);

        }
    }
}
