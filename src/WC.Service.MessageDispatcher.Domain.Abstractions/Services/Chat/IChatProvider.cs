using WC.Library.Domain.Services;
using WC.Service.MessageDispatcher.Domain.Models;

namespace WC.Service.MessageDispatcher.Domain.Services.Chat;

public interface IChatProvider : IDataProvider<ChatModel>;