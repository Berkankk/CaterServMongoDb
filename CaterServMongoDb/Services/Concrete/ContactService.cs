using AutoMapper;
using CaterServMongoDb.DataAccess.Entities;
using CaterServMongoDb.Dtos.ContactDtos;
using CaterServMongoDb.Services.Abstract;
using CaterServMongoDb.Settings;
using MongoDB.Driver;

namespace CaterServMongoDb.Services.Concrete
{
    public class ContactService : IContactService
    {
        private readonly IMongoCollection<Contact> _contactCollection;
        private readonly IMapper _mapper;

        public ContactService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var dataBase = client.GetDatabase(databaseSettings.DatabaseName);
            _contactCollection = dataBase.GetCollection<Contact>(databaseSettings.ContactCollectionName);
            _mapper = mapper;
        }

        public async Task CreateContact(CreateContactDto createContact)
        {
            var value = _mapper.Map<Contact>(createContact);
            await _contactCollection.InsertOneAsync(value);
        }

        public async Task DeleteContact(string id)
        {
            await _contactCollection.DeleteOneAsync(x => x.ContactID == id);
        }

        public async Task<List<ResultContactDto>> GetAllContact()
        {
            var value = await _contactCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultContactDto>>(value);
        }

        public async Task<ResultContactDto> GetContactByID(string id)
        {
            var value = _contactCollection.Find(x => x.ContactID == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultContactDto>(value);
        }

        public async Task UpdateContact(UpdateContactDto updateContact)
        {
            var value =  _mapper.Map<Contact>(updateContact);
            await _contactCollection.FindOneAndReplaceAsync(x =>x.ContactID == value.ContactID, value);
        }
    }
}
