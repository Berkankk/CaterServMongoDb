using CaterServMongoDb.Dtos.ContactDtos;

namespace CaterServMongoDb.Services.Abstract
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllContact(); 
        Task<ResultContactDto> GetContactByID(string id);

        Task UpdateContact(UpdateContactDto updateContact);
        Task DeleteContact(string id);
        Task CreateContact(CreateContactDto createContact);
    }
}
