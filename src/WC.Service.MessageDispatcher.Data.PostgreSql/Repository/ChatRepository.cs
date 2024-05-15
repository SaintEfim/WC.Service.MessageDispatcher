using Microsoft.Extensions.Logging;
using WC.Service.MessageDispatcher.Data.Repository;
using WC.Service.MessageDispatcher.Data.PostgreSql.Context;

namespace WC.Service.MessageDispatcher.Data.PostgreSql.Repository;

public class ChatRepository : ChatRepository<MessageDispatcherDbContext>
{
    public ChatRepository(MessageDispatcherDbContext context, ILogger<ChatRepository> logger) :
        base(
            context, logger)
    {
    }
}