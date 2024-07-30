using CaterServMongoDb.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDb.Controllers
{
    public class UIProductController : Controller
    {
        private readonly IPRoductService _productService;

        public UIProductController(IPRoductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _productService.GetProductsListAndCategoriesAsync();
            return View(values);
        }
    }
}
