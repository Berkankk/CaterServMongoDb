using CaterServMongoDb.Dtos.BookingDtos;

namespace CaterServMongoDb.Services.Abstract
{
    public interface IBookingService
    {
        Task<List<ResultBookingDto>> GetAllBookings(); //Tüm rezervasyonları getir

        Task<ResultBookingDto> GetBookingByID(string id); // Rezervasyonu idsine göre getir

        Task UpdateBooking(UpdateBookingDto updateBookingDto); //Güncelleme için dto ya bak
        Task CreateBooking(CreateBookingDto createBookingDto); //Yeni rezervasyon yapalım
        Task DeleteBooking(string id); //id ye göre silme işlemi

        Task ApproveBooking(string id);
        Task CancelBooking(string id);
        Task WaitingBooking(string id);
        Task<List<ResultBookingDto>> SearchBookingByVisitorNameSurname(string nameSurname);

        Task<List<ResultBookingDto>> Get10BookingAsync();
    }
}
