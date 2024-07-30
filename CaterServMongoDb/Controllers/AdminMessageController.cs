using AutoMapper;
using CaterServMongoDb.Services.Abstract;
using CaterServMongoDb.Services.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDb.Controllers
{
    public class AdminMessageController : Controller
    { 
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;
        public AdminMessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var value = await _messageService.GetAllMessages();
            return View(value);
        }
        public async Task<IActionResult> DeleteMessage(string id)
        {
            await _messageService.DeleteMessage(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> ChangeMessageStatus(string id)
        {
            await _messageService.SetMessageReadStatus(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetMessageDetail(string id)
        {
            var value = await _messageService.GetMessageById(id);
            return View(value);
        }
    }
}
