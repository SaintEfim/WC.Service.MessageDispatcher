using WC.Library.Data.Models;

namespace WC.Service.MessageDispatcher.Data.Models;

public class MessageEntity : EntityBase
{
    public Guid ChatId { get; set; }
    public Guid UserId { get; set; }
    public string Text { get; set; } = string.Empty;
    public DateTime SentTime { get; set; }
    public ChatEntity Chat { get; set; } = null!;
}