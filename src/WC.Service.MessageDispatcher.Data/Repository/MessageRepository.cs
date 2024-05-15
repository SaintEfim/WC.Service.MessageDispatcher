using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WC.Library.Data.Repository;
using WC.Service.MessageDispatcher.Data.Models;

namespace WC.Service.MessageDispatcher.Data.Repository;

public class MessageRepository<TDbContext> : RepositoryBase<MessageRepository<TDbContext>, TDbContext, MessageEntity>
    where TDbContext : DbContext
{
    protected MessageRepository(TDbContext context, ILogger<MessageRepository<TDbContext>> logger) :
        base(
            context, logger)
    {
    }
}