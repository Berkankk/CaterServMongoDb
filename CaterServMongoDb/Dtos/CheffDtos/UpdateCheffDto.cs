namespace CaterServMongoDb.Dtos.CheffDtos
{
    public class UpdateCheffDto
    {
        public string CheffID { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public IFormFile File { get; set; }
    }
}
