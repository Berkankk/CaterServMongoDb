namespace CaterServMongoDb.Dtos.FeatureDtos
{
    public class CreateFeatureDto
    {
       
        public string Title { get; set; }
        public string ImageUrl { get; set; }

        public IFormFile File { get; set; }
    }
}
