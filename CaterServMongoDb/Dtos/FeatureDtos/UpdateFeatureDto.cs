namespace CaterServMongoDb.Dtos.FeatureDtos
{
    public class UpdateFeatureDto
    {
        public string FeatureID { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile File { get; set; }
    }
}
