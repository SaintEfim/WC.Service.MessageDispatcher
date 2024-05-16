using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;
using WC.Library.Domain.Services;
using WC.Service.MessageDispatcher.Data.Models;
using WC.Service.MessageDispatcher.Data.Repository;
using WC.Service.MessageDispatcher.Domain.Models;

namespace WC.Service.MessageDispatcher.Domain.Services.Message;

public class MessageManager : DataManagerBase<MessageManager, IMessageRepository, MessageModel, MessageEntity>, IMessageManager
{
    public MessageManager(IMapper mapper, ILogger<MessageManager> logger, IMessageRepository repository,
        IEnumerable<IValidator> validators) : base(mapper, logger, repository, validators)
    {
    }
}