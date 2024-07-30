namespace CaterServMongoDb.Dtos.AboutDtos
{
    public class CreateAboutDto
    {
     
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Property1 { get; set; }
        public string Property2 { get; set; }
        public IFormFile File { get; set; }
    }
}
