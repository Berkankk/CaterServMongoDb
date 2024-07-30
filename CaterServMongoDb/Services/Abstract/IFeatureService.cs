using CaterServMongoDb.Dtos.FeatureDtos;

namespace CaterServMongoDb.Services.Abstract
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDto>> GetAllFeatures();
        Task<ResultFeatureDto> GetFeatureById(string id);
        Task UpdateFeature(UpdateFeatureDto featureDto);
        Task CreateFeature(CreateFeatureDto featureDto);
        Task DeleteFeature(string id);
    }
}
