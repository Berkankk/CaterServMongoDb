using AutoMapper;
using CaterServMongoDb.DataAccess.Entities;
using CaterServMongoDb.Dtos.BookingDtos;
using CaterServMongoDb.Services.Abstract;
using CaterServMongoDb.Settings;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace CaterServMongoDb.Services.Concrete
{
    public class BookingService : IBookingService
    {
        private readonly IMongoCollection<Booking> _bookingCollection;
        private readonly IMapper _mapper;

        public BookingService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _bookingCollection = database.GetCollection<Booking>(databaseSettings.BookingCollectionName);
            _mapper = mapper;
        }

        public async Task ApproveBooking(string id)
        {
            var values = await _bookingCollection.Find(x => x.BookingID == id).FirstOrDefaultAsync();
            values.Status = "Rezervasyonunuz Onaylandı";
            _bookingCollection.FindOneAndReplace(x => x.BookingID == id, values);
        }

        public async Task CancelBooking(string id)
        {
            var value = await _bookingCollection.Find(x => x.BookingID == id).FirstOrDefaultAsync();
            value.Status = "Rezervasyonunuz İptal Edildi";
            _bookingCollection.FindOneAndReplace(x => x.BookingID == id, value);
        }

        public async Task CreateBooking(CreateBookingDto createBookingDto)
        {
            var value = _mapper.Map<Booking>(createBookingDto);
            await _bookingCollection.InsertOneAsync(value);
        }

        public async Task DeleteBooking(string id)
        {
            await _bookingCollection.DeleteOneAsync(x => x.BookingID == id);
        }

        public async Task<List<ResultBookingDto>> Get10BookingAsync()
        {
            var value = await _bookingCollection.AsQueryable().Take(10).ToListAsync();
            return _mapper.Map<List<ResultBookingDto>>(value);
        }

        public async Task<List<ResultBookingDto>> GetAllBookings()
        {
            var value = await _bookingCollection.AsQueryable().ToListAsync();
            //var value = await _bookingCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultBookingDto>>(value);
        }

        public async Task<ResultBookingDto> GetBookingByID(string id)
        {
            var value = await _bookingCollection.Find(x => x.BookingID == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultBookingDto>(value);
        }

        public async Task<List<ResultBookingDto>> SearchBookingByVisitorNameSurname(string nameSurname)
        {
            var value = await _bookingCollection.AsQueryable().Where(x => x.NameSurname == nameSurname).ToListAsync();
            return _mapper.Map<List<ResultBookingDto>>(value);
        }

        public async Task UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var value = _mapper.Map<Booking>(updateBookingDto);
            await _bookingCollection.FindOneAndReplaceAsync(x => x.BookingID == value.BookingID, value);
        }

        public async Task WaitingBooking(string id)
        {
            var value = await _bookingCollection.Find(x => x.BookingID == id).FirstOrDefaultAsync();
            value.Status = "Rezarvasyon Beklemede, Kullanıcı Aranacak";
            _bookingCollection.FindOneAndReplace(x => x.BookingID == id, value);
        }
    }
}
