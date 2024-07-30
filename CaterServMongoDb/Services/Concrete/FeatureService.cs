using AutoMapper;
using CaterServMongoDb.DataAccess.Entities;
using CaterServMongoDb.Dtos.FeatureDtos;
using CaterServMongoDb.Services.Abstract;
using CaterServMongoDb.Settings;
using MongoDB.Driver;
using System.Net.NetworkInformation;

namespace CaterServMongoDb.Services.Concrete
{
    public class FeatureService : IFeatureService
    {
        private readonly IMongoCollection<Feature> _featureCollection;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public FeatureService(IMapper mapper, IDatabaseSettings databaseSettings, IImageService imageService)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _featureCollection = database.GetCollection<Feature>(databaseSettings.FeatureCollectionName);

            _mapper = mapper;
            _imageService = imageService;

            //Her seferince bağlantı vermek yerine tek seferde tüm bağlantıları verdik
        }
        public async Task CreateFeature(CreateFeatureDto featureDto)
        {
            var ImageUrl = await _imageService.CreateImage(featureDto.File);
            featureDto.ImageUrl = ImageUrl;

            var values = _mapper.Map<Feature>(featureDto);   //Mapleme işlemini yaptık
            await _featureCollection.InsertOneAsync(values);
        }

        public async Task DeleteFeature(string id)
        {
            await _featureCollection.DeleteOneAsync(x => x.FeatureID == id);
        }

        public async Task<List<ResultFeatureDto>> GetAllFeatures()
        {
            var value = await _featureCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultFeatureDto>>(value);
        }

        public async Task<ResultFeatureDto> GetFeatureById(string id)
        {
            var value = await _featureCollection.Find(x => x.FeatureID == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultFeatureDto>(value);
        }

        public async Task UpdateFeature(UpdateFeatureDto featureDto)
        {
            var ImageUrl = await _imageService.CreateImage(featureDto.File);
            featureDto.ImageUrl = ImageUrl;

            var value = _mapper.Map<Feature>(featureDto);
            await _featureCollection.FindOneAndReplaceAsync(x => x.FeatureID == value.FeatureID, value);
        }
    }
}
