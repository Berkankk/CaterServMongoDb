using CaterServMongoDb.Dtos.MessageDtos;

namespace CaterServMongoDb.Services.Abstract
{
    public interface IMessageService
    {
        Task<List<ResultMessageDto>> GetAllMessages();
        Task<ResultMessageDto> GetMessageById(string id);
        Task CreateMessage(CreateMessageDto MessageDto);
        Task DeleteMessage(string id);
        Task SetMessageReadStatus(string id);
    }
}
