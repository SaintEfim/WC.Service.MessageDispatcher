using WC.Library.Domain.Models;

namespace WC.Service.MessageDispatcher.Domain.Models;

public class ChatModel : ModelBase
{
    public string Name { get; set; } = string.Empty;
    public bool IsGroupChat { get; set; }
    public List<Guid> UserIds { get; set; } = null!;
    public List<MessageModel>? Messages { get; set; }
}