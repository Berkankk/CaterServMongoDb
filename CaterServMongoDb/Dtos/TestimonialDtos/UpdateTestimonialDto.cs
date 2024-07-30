namespace CaterServMongoDb.Dtos.TestimonialDtos
{
    public class UpdateTestimonialDto
    {
        public string TestimonialID { get; set; }
        public IFormFile File { get; set; }
        public string ImageUrl { get; set; }
        public int Star { get; set; }
        public string Name { get; set; }
        public DateTime CommnetDate { get; set; }
        public string Commet { get; set; }
    }
}
