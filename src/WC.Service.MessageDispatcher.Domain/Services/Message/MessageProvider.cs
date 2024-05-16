using AutoMapper;
using Microsoft.Extensions.Logging;
using WC.Library.Domain.Services;
using WC.Service.MessageDispatcher.Data.Models;
using WC.Service.MessageDispatcher.Data.Repository;
using WC.Service.MessageDispatcher.Domain.Models;

namespace WC.Service.MessageDispatcher.Domain.Services.Message;

public class MessageProvider : DataProviderBase<MessageProvider, IMessageRepository, MessageModel, MessageEntity>, IMessageProvider
{
    public MessageProvider(IMapper mapper, ILogger<MessageProvider> logger,
        IMessageRepository repository) : base(mapper, logger, repository)
    {
    }
}