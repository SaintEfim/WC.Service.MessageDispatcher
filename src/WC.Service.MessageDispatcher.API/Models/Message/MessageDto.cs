using WC.Library.Web.Models;

namespace WC.Service.MessageDispatcher.API.Models.Message;

public class MessageDto : DtoBase
{
    public Guid ChatId { get; set; }
    public Guid UserId { get; set; }
    public string Text { get; set; } = string.Empty;
    public DateTime SentTime { get; set; }
}