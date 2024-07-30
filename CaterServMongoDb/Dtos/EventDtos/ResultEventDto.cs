using CaterServMongoDb.Dtos.EventCategoryDtos;

namespace CaterServMongoDb.Dtos.EventDtos
{
    public class ResultEventDto
    {
        public string EventID { get; set; }
        public string ImageUrl { get; set; }
        public string  CategoryName { get; set; }

        public string EventCategoriesID { get; set; }
        //public string EventCategoriesName { get; set; }

        public ResultEventCategoryDto EventCategory { get; set; }
    }
}
