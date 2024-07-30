using AutoMapper;
using CaterServMongoDb.Dtos.EventCategoryDtos;
using CaterServMongoDb.Dtos.EventDtos;
using CaterServMongoDb.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDb.Controllers
{
    public class AdminEventCategoryController : Controller
    {
        private readonly IEventCategoryService _eventCategoryService;
        private readonly IMapper _mapper;
        public AdminEventCategoryController(IEventCategoryService eventCategoryService, IMapper mapper)
        {
            _eventCategoryService = eventCategoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _eventCategoryService.GetAllEventCategorys();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateEventCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEventCategory(CreateEventCategoryDto createEventCategoryDto)
        {
            await _eventCategoryService.CreateEventCategory(createEventCategoryDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteEventCategory(string id)
        {
            await _eventCategoryService.DeleteEventCategory(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateEventCategory(string id)
        {
            var value = await _eventCategoryService.GetEventCategoryById(id);
            var gnc = _mapper.Map<UpdateEventCategoryDto>(value);
            return View(gnc);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEventCategory(UpdateEventCategoryDto updateEventCategoryDto)
        {
            await _eventCategoryService.UpdateEventCategory(updateEventCategoryDto);
            return RedirectToAction("Index");
        }
    }
}
