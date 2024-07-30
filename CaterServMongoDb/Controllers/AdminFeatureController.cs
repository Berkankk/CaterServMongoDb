using AutoMapper;
using CaterServMongoDb.Dtos.FeatureDtos;
using CaterServMongoDb.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDb.Controllers
{
    public class AdminFeatureController : Controller
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;
        public AdminFeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var value = await _featureService.GetAllFeatures();
            return View(value);
        }
        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _featureService.DeleteFeature(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            await _featureService.CreateFeature(createFeatureDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            var value = await _featureService.GetFeatureById(id);
            var gnc = _mapper.Map<UpdateFeatureDto>(value);
            return View(gnc);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            await _featureService.UpdateFeature(updateFeatureDto);
            return RedirectToAction("Index");
        }
    }
}
