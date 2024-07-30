 using AutoMapper;
using CaterServMongoDb.Dtos.CategoryDtos;
using CaterServMongoDb.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDb.Controllers
{
   
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var value = await _categoryService.GetAllCategories(); //tüm kategorileri getir ve bunu asenkron olarak yap
            return View(value); //liste olarak dönüyor bize ve result categorydto türünde dönüyor
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategory(createCategoryDto); //Createcategory dto dan ekleme işlemlerini yapacağız
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategory(id);  //id ye göre silme işlemi yaptık
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateCategory(string id)
        {
            var value = await _categoryService.GetCategoryById(id); //id ye göre veri getir önce 
            var map = _mapper.Map<UpdateCategoryDto>(value);
            return View(map); //value değerini dön
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategory(updateCategoryDto);//sonra post işemi ile güncelleme işlemi yapacağız
            return RedirectToAction("Index");
        }
    }
}
