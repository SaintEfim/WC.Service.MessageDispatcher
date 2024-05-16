using WC.Library.Web.Models;
using WC.Service.MessageDispatcher.API.Models.Message;

namespace WC.Service.MessageDispatcher.API.Models.Chat;

public class ChatDto : DtoBase
{
    public string Name { get; set; } = string.Empty;
    public bool IsGroupChat { get; set; }
    public List<Guid> UserIds { get; set; } = null!;
    public List<MessageDto>? Messages { get; set; }
}