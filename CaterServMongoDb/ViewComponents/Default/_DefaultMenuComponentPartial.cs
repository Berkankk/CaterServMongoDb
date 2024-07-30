using CaterServMongoDb.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDb.ViewComponents.Default
{
    public class _DefaultMenuComponentPartial : ViewComponent
    {
        private readonly IPRoductService _productService;
        private readonly ICategoryService _categoryService;
        public _DefaultMenuComponentPartial(IPRoductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _productService.GetProductsListAndCategoriesAsync();
            //var values = await _productService.GetProductsListAndCategoriesAsync();
            ViewBag.Categories = await _categoryService.GetAllCategories();
            return View(value);
        }
    }
}
