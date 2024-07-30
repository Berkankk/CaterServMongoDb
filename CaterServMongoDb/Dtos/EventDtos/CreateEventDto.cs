namespace CaterServMongoDb.Dtos.EventDtos
{
    public class CreateEventDto
    {
        public string EventID { get; set; }
        public IFormFile File { get; set; }
        public string ImageUrl { get; set; }
        public string  CategoryName { get; set; }

        public string EventCategoriesID { get; set; }
    }
}
