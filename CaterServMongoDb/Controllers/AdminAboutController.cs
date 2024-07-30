using AutoMapper;
using CaterServMongoDb.Dtos.AboutDtos;
using CaterServMongoDb.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDb.Controllers
{
    public class AdminAboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AdminAboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var value = await _aboutService.GettAllAbouts();
            return View(value);
        }

        public IActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await _aboutService.CreateAbout(createAboutDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            var value = await _aboutService.GetAboutByID(id);
            var gnc = _mapper.Map<UpdateAboutDto>(value);
            return View(gnc);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            await _aboutService.UpdateAbout(updateAboutDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _aboutService.DeleteAbout(id);
            return RedirectToAction("Index");
        }
    }
}
