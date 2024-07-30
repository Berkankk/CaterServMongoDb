using AutoMapper;
using CaterServMongoDb.DataAccess.Entities;
using CaterServMongoDb.Dtos.CategoryDtos;
using CaterServMongoDb.Dtos.ProductDtos;
using CaterServMongoDb.Services.Abstract;
using CaterServMongoDb.Settings;
using MongoDB.Driver;

namespace CaterServMongoDb.Services.Concrete
{
    public class ProductService : IPRoductService
    {
        private readonly IMongoCollection<Product> _product;
        private readonly IMongoCollection<Category> _category;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings, IImageService imageService)
        {
            _mapper = mapper;

            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _product = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _category = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _imageService = imageService;
        }

        public async Task CreateProduct(CreateProductDto createProductDto)
        {
            string imageUrl = await _imageService.CreateImage(createProductDto.File);


            var value = _mapper.Map<Product>(createProductDto);
            value.ImageUrl = imageUrl;
            await _product.InsertOneAsync(value);

        }

        public async Task DeleteProduct(string id)
        {
            await _product.DeleteOneAsync(x => x.ProductID == id);
        }

        public async Task<List<ResultProductDto>> GetAllProducts()
        {
            var values = await _product.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<ResultProductDto> GetProductById(string id)
        {
            var value = await _product.Find(x => x.ProductID == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultProductDto>(value);
        }

        public async Task<List<ResultProductWithCategories>> GetProductsListAndCategoriesAsync()
        {
            var ProductValues = await _product.AsQueryable().ToListAsync();


            List<ResultProductWithCategories> result = new List<ResultProductWithCategories>();
            foreach (var item in ProductValues)
            {

                if (item.Category != null)
                {
                    var categories = _category.Find(x => x.CategoryID == item.Category.CategoryID).FirstOrDefault();




                    if (categories != null)
                    {
                        var mappedValue = _mapper.Map<ResultCategoryDto>(categories);

                        result.Add(new ResultProductWithCategories
                        {
                            Description = item.Description,
                            ImageUrl = item.ImageUrl,
                            Price = item.Price,
                            ProductID = item.ProductID,
                            ProductName = item.ProductName,
                            IsVegetarian = item.IsVegetarian,
                            Category = mappedValue,

                        });
                    }
                }

            }
            return result;
        }

        //public async Task<List<ResultProductWithCategories>> GetProductsListAndCategoriesAsync()
        //{
        //    var ProductValues = await _product.AsQueryable().ToListAsync();


        //    List<ResultProductWithCategories> result = new List<ResultProductWithCategories>();
        //    foreach (var item in ProductValues)
        //    {
        //        var categories = _category.Find(x => x.CategoryID == item.ProductID).FirstOrDefault();

        //        if (categories != null)
        //        {
        //            var mappedValue = _mapper.Map<ResultCategoryDto>(categories);

        //            result.Add(new ResultProductWithCategories
        //            {
        //                Description = item.Description,
        //                ImageUrl = item.ImageUrl,
        //                Price = item.Price,
        //                ProductID = item.ProductID,
        //                ProductName = item.ProductName,

        //                Category = mappedValue,

        //            });
        //        }

        //    }
        //    return result;
        //}

        public async Task UpdateProduct(UpdateProductDto updateProductDto)
        {
            string imageUrl = await _imageService.CreateImage(updateProductDto.File);
            updateProductDto.ImageUrl = imageUrl;

            var product = _mapper.Map<Product>(updateProductDto);
            await _product.FindOneAndReplaceAsync(x => x.ProductID == updateProductDto.ProductID, product);
        }
    }
}
