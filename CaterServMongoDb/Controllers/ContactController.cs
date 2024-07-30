using CaterServMongoDb.Dtos.MessageDtos;
using CaterServMongoDb.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDb.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMessageService _messageService;

        public ContactController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SendMessage(CreateMessageDto createMessage)
        {
            createMessage.Date = DateTime.Now;
            createMessage.IsRead = false; //default değer olarak false verdik

            await _messageService.CreateMessage(createMessage);
            TempData["addcontactresult"] = true;
            return View();
        }
    }
}
