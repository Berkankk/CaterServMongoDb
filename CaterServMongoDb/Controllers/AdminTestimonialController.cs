using AutoMapper;
using CaterServMongoDb.Dtos.TestimonialDtos;
using CaterServMongoDb.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDb.Controllers
{
    public class AdminTestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;
        public AdminTestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _testimonialService.GetAllTestimonial();
            return View(values);
        }
        public async Task<IActionResult> DeleteTestimonial(string id)
        {
            await _testimonialService.DeleteTestimonial(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            await _testimonialService.CreateTestimonial(createTestimonialDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(string id)
        {
            var value = await _testimonialService.GetTestimonailById(id);
            var gnc = _mapper.Map<UpdateTestimonialDto>(value);
            return View(gnc);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            await _testimonialService.UpdateTestimonial(updateTestimonialDto);
            return RedirectToAction("Index");
        }
    }
}
