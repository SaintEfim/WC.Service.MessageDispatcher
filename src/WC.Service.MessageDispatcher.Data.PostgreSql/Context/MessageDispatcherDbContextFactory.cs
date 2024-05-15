using Microsoft.Extensions.Configuration;
using WC.Library.Data.PostgreSql.Context;

namespace WC.Service.MessageDispatcher.Data.PostgreSql.Context;

public class MessageDispatcherDbContextFactory  : PostgreSqlDbContextFactoryBase<MessageDispatcherDbContext>
{
    protected override string ConnectionString => "WorkChatDB";
    
    public MessageDispatcherDbContextFactory(IConfiguration configuration) : base(configuration)
    {
    }
}