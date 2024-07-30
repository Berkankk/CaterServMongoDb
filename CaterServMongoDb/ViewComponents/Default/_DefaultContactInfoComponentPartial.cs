using CaterServMongoDb.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDb.ViewComponents.Default
{
    public class _DefaultContactInfoComponentPartial : ViewComponent
    {
        private readonly IContactService _contactService;

        public _DefaultContactInfoComponentPartial(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _contactService.GetAllContact();
            return View(value);
        }
    }
}
