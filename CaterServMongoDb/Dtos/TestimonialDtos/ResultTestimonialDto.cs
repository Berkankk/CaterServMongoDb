namespace CaterServMongoDb.Dtos.TestimonialDtos
{
    public class ResultTestimonialDto
    {
        public string TestimonialID { get; set; }

        public string ImageUrl { get; set; }
        public int Star { get; set; }
        public string Name { get; set; }
        public DateTime CommnetDate { get; set; }
        public string Commet { get; set; }
    }
}
