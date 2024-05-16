using WC.Library.Data.Models;

namespace WC.Service.MessageDispatcher.Data.Models;

public class ChatEntity : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public bool IsGroupChat { get; set; }
    public List<Guid> UserIds { get; set; } = null!;
    public List<MessageEntity>? Messages { get; set; }
}