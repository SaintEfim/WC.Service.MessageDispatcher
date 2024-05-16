using WC.Library.Data.Repository;
using WC.Service.MessageDispatcher.Data.Models;

namespace WC.Service.MessageDispatcher.Data.Repository;

public interface IMessageRepository : IRepository<MessageEntity>;