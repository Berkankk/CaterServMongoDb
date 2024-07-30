using AutoMapper;
using CaterServMongoDb.DataAccess.Entities;
using CaterServMongoDb.Dtos.CategoryDtos;
using CaterServMongoDb.Services.Abstract;
using CaterServMongoDb.Settings;
using MongoDB.Driver;

namespace CaterServMongoDb.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);

            _mapper = mapper;

            //Her seferince bağlantı vermek yerine tek seferde tüm bağlantıları verdik
        }

        public async Task CreateCategory(CreateCategoryDto categoryDto)
        {
            var values = _mapper.Map<Category>(categoryDto);   //Mapleme işlemini yaptık
            await _categoryCollection.InsertOneAsync(values); //Ekleme metodu yazdık
        }

        public async Task DeleteCategory(string id)
        {
            await _categoryCollection.DeleteOneAsync(x => x.CategoryID == id); //Silme işlemini yaptık
        }

        public async Task<List<ResultCategoryDto>> GetAllCategories()
        {
            var value = await _categoryCollection.AsQueryable().ToListAsync();  //Sorgulanabilir bir liste getiriyor bize
            return _mapper.Map<List<ResultCategoryDto>>(value); //Value ile resultcategorydto yu mapledik liste türünde yaptık
        }

        public async Task<ResultCategoryDto> GetCategoryById(string id)
        {
            var value = await _categoryCollection.Find(x => x.CategoryID == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultCategoryDto>(value);
            //Find ile değeri bulduk firstor ile de gelen ilk değeri buluk
        }

        public async Task UpdateCategory(UpdateCategoryDto categoryDtos)
        {
            var value = _mapper.Map<Category>(categoryDtos);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryID == categoryDtos.CategoryID, value);
        }

      
    }
}

