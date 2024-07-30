using CaterServMongoDb.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDb.ViewComponents.Default
{
    public class _DefaultEventComponentPartial : ViewComponent
    {
        private readonly IEventService _eventService;
        private readonly IEventCategoryService _eventCategoryService;
        public _DefaultEventComponentPartial(IEventService eventService, IEventCategoryService eventCategoryService)
        {
            _eventService = eventService;
            _eventCategoryService = eventCategoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _eventService.GetEventsWithCategories();
            var categoryList = await _eventCategoryService.GetAllEventCategorys();
            ViewBag.categoryList = categoryList;
            return View(value);
        }
    }
}
