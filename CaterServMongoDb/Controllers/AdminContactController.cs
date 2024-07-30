using AutoMapper;
using CaterServMongoDb.Dtos.ContactDtos;
using CaterServMongoDb.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace CaterServMongoDb.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public AdminContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _contactService.GetAllContact();
            return View(values);
        }
        public async Task<IActionResult> DeleteContact(string id)
        {
            await _contactService.DeleteContact(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            await _contactService.CreateContact(createContactDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateContact(string id)
        {
            var value = await _contactService.GetContactByID(id);
            var gnc = _mapper.Map<UpdateContactDto>(value);
            return View(gnc);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            await _contactService.UpdateContact(updateContactDto);
            return RedirectToAction("Index");
        }
    }
}
