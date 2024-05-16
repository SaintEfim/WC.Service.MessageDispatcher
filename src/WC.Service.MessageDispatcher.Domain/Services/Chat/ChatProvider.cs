using AutoMapper;
using Microsoft.Extensions.Logging;
using WC.Library.Domain.Services;
using WC.Service.MessageDispatcher.Data.Models;
using WC.Service.MessageDispatcher.Data.Repository;
using WC.Service.MessageDispatcher.Domain.Models;

namespace WC.Service.MessageDispatcher.Domain.Services.Chat;

public class ChatProvider :
    DataProviderBase<ChatProvider, IChatRepository, ChatModel, ChatEntity>,
    IChatProvider
{
    public ChatProvider(IMapper mapper, ILogger<ChatProvider> logger,
        IChatRepository repository) : base(mapper, logger, repository)
    {
    }
}