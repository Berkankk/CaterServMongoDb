using CaterServMongoDb.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDb.ViewComponents.Default
{
    public class _DefaultAboutComponentPartial : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public _DefaultAboutComponentPartial(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _aboutService.GettAllAbouts();
            return View(value);
        }
    }
}
