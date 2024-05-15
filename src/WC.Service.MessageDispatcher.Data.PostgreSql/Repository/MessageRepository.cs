using Microsoft.Extensions.Logging;
using WC.Service.MessageDispatcher.Data.PostgreSql.Context;
using WC.Service.MessageDispatcher.Data.Repository;

namespace WC.Service.MessageDispatcher.Data.PostgreSql.Repository;

public class MessageRepository : MessageRepository<MessageDispatcherDbContext>
{
    public MessageRepository(MessageDispatcherDbContext context, ILogger<MessageRepository> logger) :
        base(
            context, logger)
    {
    }
}