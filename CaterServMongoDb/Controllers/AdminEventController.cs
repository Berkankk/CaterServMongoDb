using AutoMapper;
using CaterServMongoDb.Dtos.EventDtos;
using CaterServMongoDb.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;

namespace CaterServMongoDb.Controllers
{
    public class AdminEventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;
        private readonly IEventCategoryService _eventCategoryService;
        public AdminEventController(IEventService eventService, IMapper mapper, IEventCategoryService eventCategoryService)
        {
            _eventService = eventService;
            _mapper = mapper;
            _eventCategoryService = eventCategoryService;
        }

        public async Task<IActionResult> Index()
        {
            var value = await _eventService.GetAllEvents();
            return View(value);
        }
        public async Task<IActionResult> DeleteEvent(string id)
        {
            await _eventService.DeleteEvent(id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> CreateEvent()
        {
            var values = await _eventCategoryService.GetAllEventCategorys();

            List<SelectListItem> selectListItems = (from x in values
                                                    select new SelectListItem
                                                    {
                                                        Text = x.CategoryName,
                                                        Value = x.CategoryName
                                                    }).ToList();
            ViewBag.EventCategoryList = selectListItems;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEvent(CreateEventDto createEventDto)
        {
            await _eventService.CreateEvent(createEventDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateEvent(string id)
        {
            var value = await _eventService.GetEventById(id);
            var mappedValue = _mapper.Map<UpdateEventDto>(value);


            var values = await _eventCategoryService.GetAllEventCategorys();

            List<SelectListItem> selectListItems = (from x in values
                                                    select new SelectListItem
                                                    {
                                                        Text = x.CategoryName,
                                                        Value = x.EventCategoriesID.ToString()
                                                    }).ToList();
            ViewBag.EventCategoryList = selectListItems;

            return View(mappedValue);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEvent(UpdateEventDto updateEventDto)
        {
            await _eventService.UpdateEvent(updateEventDto);
            return RedirectToAction("Index");
        }

    }
}
