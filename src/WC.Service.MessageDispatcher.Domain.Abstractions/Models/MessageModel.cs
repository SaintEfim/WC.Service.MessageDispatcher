using WC.Library.Domain.Models;

namespace WC.Service.MessageDispatcher.Domain.Models;

public class MessageModel : ModelBase
{
    public Guid ChatId { get; set; }
    public Guid UserId { get; set; }
    public string Text { get; set; } = string.Empty;
    public DateTime SentTime { get; set; }
}