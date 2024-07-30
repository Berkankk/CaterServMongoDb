using CaterServMongoDb.Dtos.TestimonialDtos;

namespace CaterServMongoDb.Services.Abstract
{
    public interface ITestimonialService
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonial();
        Task<ResultTestimonialDto> GetTestimonailById(string id);
        Task UpdateTestimonial(UpdateTestimonialDto testimonailDto);
        Task CreateTestimonial(CreateTestimonialDto testimonailDto);
        Task DeleteTestimonial(string id);
    }
}
