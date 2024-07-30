using CaterServMongoDb.Dtos.CategoryDtos;

namespace CaterServMongoDb.Services.Abstract
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategories();  //Asenkron metot olduğu için task içinde yazdık.
        Task<ResultCategoryDto> GetCategoryById(string id);  //Güncelleme işleminde ıd ye gore getiriyoruz
         
        Task UpdateCategory(UpdateCategoryDto categorDtos);
        Task CreateCategory(CreateCategoryDto categorDto);
        Task DeleteCategory(string id);
    }
}
