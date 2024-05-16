using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;
using WC.Library.Domain.Services;
using WC.Service.MessageDispatcher.Data.Models;
using WC.Service.MessageDispatcher.Data.Repository;
using WC.Service.MessageDispatcher.Domain.Models;

namespace WC.Service.MessageDispatcher.Domain.Services.Chat;

public class ChatManager : DataManagerBase<ChatManager, IChatRepository, ChatModel, ChatEntity>, IChatManager
{
    public ChatManager(IMapper mapper, ILogger<ChatManager> logger, IChatRepository repository,
        IEnumerable<IValidator> validators) : base(mapper, logger, repository, validators)
    {
    }
}