using WC.Library.Domain.Services;
using WC.Service.MessageDispatcher.Domain.Models;

namespace WC.Service.MessageDispatcher.Domain.Services.Message;

public interface IMessageProvider: IDataProvider<MessageModel>;