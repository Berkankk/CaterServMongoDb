using CaterServMongoDb.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDb.ViewComponents.Default
{
    public class _DefaultServiceComponentPartial : ViewComponent
    {
        private readonly IServiceService _serviceService;

        public _DefaultServiceComponentPartial(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _serviceService.GetAllServices();
            return View(value);
        }
    }
}
