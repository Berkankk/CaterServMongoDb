using AutoMapper;
using CaterServMongoDb.DataAccess.Entities;
using CaterServMongoDb.Dtos.MessageDtos;
using CaterServMongoDb.Services.Abstract;
using CaterServMongoDb.Settings;
using MongoDB.Driver;

namespace CaterServMongoDb.Services.Concrete
{
    public class MessageService : IMessageService
    {
        private readonly IMongoCollection<Message> _messageCollection;
        private readonly IMapper _mapper;

        public MessageService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var dataBase = client.GetDatabase(databaseSettings.DatabaseName);
            _messageCollection = dataBase.GetCollection<Message>(databaseSettings.MessageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateMessage(CreateMessageDto MessageDto)
        {
            var value = _mapper.Map<Message>(MessageDto);
            await _messageCollection.InsertOneAsync(value);
        }

        public async Task DeleteMessage(string id)
        {
            await _messageCollection.DeleteOneAsync(x => x.MessageID == id);
        }

        public async Task<List<ResultMessageDto>> GetAllMessages()
        {
            var value = await _messageCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultMessageDto>>(value);
        }

        public async Task<ResultMessageDto> GetMessageById(string id)
        {
            var value = await _messageCollection.Find(x => x.MessageID == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultMessageDto>(value);
        }

        public async Task SetMessageReadStatus(string id)
        {
            var value = await GetMessageById(id);

            if (value.IsRead == true)
            {
                value.IsRead = false;
            }
            else
            {
                value.IsRead = true;
            }
            var maps = _mapper.Map<Message>(value);
            await _messageCollection.FindOneAndReplaceAsync(x => x.MessageID == id, maps);
        }
    }
}
