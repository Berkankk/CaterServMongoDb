using AutoMapper;
using CaterServMongoDb.DataAccess.Entities;
using CaterServMongoDb.Dtos.TestimonialDtos;
using CaterServMongoDb.Services.Abstract;
using CaterServMongoDb.Settings;
using MongoDB.Driver;

namespace CaterServMongoDb.Services.Concrete
{
    public class TestimonialService : ITestimonialService
    {
        private readonly IMongoCollection<Testimonial> _testimonialCollection;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public TestimonialService(IMapper mapper, IDatabaseSettings databaseSettings, IImageService imageService)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var dataBase = client.GetDatabase(databaseSettings.DatabaseName);
            _testimonialCollection = dataBase.GetCollection<Testimonial>(databaseSettings.TestimonialCollectionName);
            _mapper = mapper;
            _imageService = imageService;
        }

        public async Task CreateTestimonial(CreateTestimonialDto testimonailDto)
        {
            var ImageUrl = await _imageService.CreateImage(testimonailDto.File);
            testimonailDto.ImageUrl = ImageUrl;

            var value = _mapper.Map<Testimonial>(testimonailDto);
            await _testimonialCollection.InsertOneAsync(value);
        }

        public async Task DeleteTestimonial(string id)
        {
            await _testimonialCollection.DeleteOneAsync(x => x.TestimonialID == id);
        }

        public async Task<List<ResultTestimonialDto>> GetAllTestimonial()
        {
            var value = await _testimonialCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultTestimonialDto>>(value);
        }

        public async Task<ResultTestimonialDto> GetTestimonailById(string id)
        {
            var value = await _testimonialCollection.Find(x => x.TestimonialID == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultTestimonialDto>(value);
        }

        public async Task UpdateTestimonial(UpdateTestimonialDto testimonailDto)
        {
            var ImageUrl = await _imageService.CreateImage(testimonailDto.File);
            testimonailDto.ImageUrl = ImageUrl;

            var values = _mapper.Map<Testimonial>(testimonailDto);
            values.CommnetDate = DateTime.Now;
            await _testimonialCollection.FindOneAndReplaceAsync(x => x.TestimonialID == values.TestimonialID, values);
        }
    }
}
