using WC.Library.Data.Models;

namespace WC.Service.MessageDispatcher.Data.Models;

public class ChatEntity : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public bool IsGroupChat { get; set; }
    public ICollection<Guid> UserIds { get; set; } = null!;
    public ICollection<MessageEntity>? Messages { get; set; }
}