using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WC.Library.Data.Repository;
using WC.Service.MessageDispatcher.Data.Models;

namespace WC.Service.MessageDispatcher.Data.Repository;

public class ChatRepository<TDbContext> : RepositoryBase<ChatRepository<TDbContext>, TDbContext, ChatEntity>,
    IChatRepository
    where TDbContext : DbContext
{
    protected ChatRepository(TDbContext context, ILogger<ChatRepository<TDbContext>> logger) :
        base(
            context, logger)
    {
    }
}