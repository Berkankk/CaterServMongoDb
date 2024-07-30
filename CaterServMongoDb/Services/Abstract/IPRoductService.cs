using CaterServMongoDb.Dtos.CategoryDtos;
using CaterServMongoDb.Dtos.ProductDtos;

namespace CaterServMongoDb.Services.Abstract
{
    public interface IPRoductService
    {
        Task<List<ResultProductDto>> GetAllProducts();  //Asenkron metot olduğu için task içinde yazdık.
        Task<ResultProductDto> GetProductById(string id);  //Güncelleme işleminde ıd ye gore getiriyoruz

        Task UpdateProduct(UpdateProductDto updateProductDto);
        Task CreateProduct(CreateProductDto createProductDto);
        Task DeleteProduct(string id);
        //Task<List<ResultProductWithCategories>> GetProductsListAndCategoriesAsync();
        Task<List<ResultProductWithCategories>> GetProductsListAndCategoriesAsync();
    }
}
