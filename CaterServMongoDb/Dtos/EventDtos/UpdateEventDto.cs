namespace CaterServMongoDb.Dtos.EventDtos
{
    public class UpdateEventDto
    {
        public string EventID { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile File { get; set; }
        public string EventCategoriesID { get; set; }
        public string CategoryName { get; set; }
    }
}
