using CaterServMongoDb.DataAccess.Entities;
using CaterServMongoDb.Dtos.DashboardDtos;
using CaterServMongoDb.Services.Abstract;
using CaterServMongoDb.Settings;
using MongoDB.Driver;

namespace CaterServMongoDb.Services.Concrete
{
    public class DashboardService : IDashboardService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Booking> _bookingCollection;
        private readonly IMongoCollection<Message> _messageCollection;

        public DashboardService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _bookingCollection = database.GetCollection<Booking>(databaseSettings.BookingCollectionName);
            _messageCollection = database.GetCollection<Message>(databaseSettings.MessageCollectionName);

        }
        public ResultDashboardStatisticDto GetDashboardStatistic()
        {
            ResultDashboardStatisticDto result = new ResultDashboardStatisticDto()
            {
                CategoryCount = _categoryCollection.AsQueryable().Count(),
                MenuCount = _productCollection.AsQueryable().Count(),

                ExpensiveMenuName = _productCollection.AsQueryable().OrderByDescending(x => x.Price).Take(1).Select(x => x.ProductName).FirstOrDefault(),
                CheapMenuName = _productCollection.AsQueryable().OrderBy(x => x.Price).Take(1).Select(x => x.ProductName).FirstOrDefault(),
                MessageCount = _messageCollection.AsQueryable().Count(),
                ReservationCount = _bookingCollection.AsQueryable().Count(),

            };


            return result;
        }
    }
}
