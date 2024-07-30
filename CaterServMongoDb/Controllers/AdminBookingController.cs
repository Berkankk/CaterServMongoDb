using AutoMapper;
using CaterServMongoDb.Dtos.BookingDtos;
using CaterServMongoDb.Services.Abstract;
using CaterServMongoDb.Services.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CaterServMongoDb.Controllers
{
    public class AdminBookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IEventCategoryService _eventCategoryService;
        private readonly IMapper _mapper;
        public AdminBookingController(IBookingService bookingService, IEventCategoryService eventCategoryService, IMapper mapper)
        {
            _bookingService = bookingService;
            _eventCategoryService = eventCategoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _bookingService.GetAllBookings();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateBooking()
        {
            var values = await _eventCategoryService.GetAllEventCategorys();
            List<SelectListItem> categoriesList = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.EventCategoriesID,

                                                   }).ToList();

            ViewBag.CategoriesList = categoriesList;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
        {
            createBookingDto.Status = "Onay Bekliyor";
            await _bookingService.CreateBooking(createBookingDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBooking(string id)
        {
            var value = await _bookingService.GetBookingByID(id);
            var mappedValues = _mapper.Map<UpdateBookingDto>(value);
            var values = await _eventCategoryService.GetAllEventCategorys();
            List<SelectListItem> categoriesList = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.EventCategoriesID,

                                                   }).ToList();

            ViewBag.CategoriesList = categoriesList;
            return View(mappedValues);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto createBookingDto)
        {
            await _bookingService.UpdateBooking(createBookingDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteBooking(string id)
        {
            await _bookingService.DeleteBooking(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ApproveBooking(string id)
        {
            await _bookingService.ApproveBooking(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> WaitingBooking(string id)
        {
            await _bookingService.WaitingBooking(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> CancelBooking(string id)
        {
            await _bookingService.CancelBooking(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> SearchBookingByNameSurname(string NameSurname)
        {
            var value = await _bookingService.SearchBookingByVisitorNameSurname(NameSurname);
            TempData["showallbookings"] = "true";
            return View("Index", value);
        }
    }
}
