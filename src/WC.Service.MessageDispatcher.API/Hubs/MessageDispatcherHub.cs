using System.Collections.Concurrent;
using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;
using WC.Service.MessageDispatcher.Domain.Models;
using WC.Service.MessageDispatcher.Domain.Services.Chat;
using WC.Service.MessageDispatcher.Domain.Services.Message;

namespace WC.Service.MessageDispatcher.API.Hubs;

public class MessageDispatcherHub : Hub
{
    private readonly IChatManager _chatManager;
    private readonly IChatProvider _chatProvider;
    private readonly IMessageManager _messageManager;
    private static readonly ConcurrentDictionary<Guid, string> ConnectedUsers = new();

    public MessageDispatcherHub(IChatManager chatManager, IMessageManager messageManager, IChatProvider chatProvider)
    {
        _chatManager = chatManager;
        _messageManager = messageManager;
        _chatProvider = chatProvider;
    }

    private void AddUser(string connectionId)
    {
        ConnectedUsers.TryAdd(GetUserId(), connectionId);
    }

    public override Task OnConnectedAsync()
    {
        AddUser(Context.ConnectionId);
        return base.OnConnectedAsync();
    }

    private Guid GetUserId()
    {
        var userIdClaim = Context.User?.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
        {
            throw new HubException("User identifier claim not found.");
        }

        return Guid.Parse(userIdClaim.Value);
    }

    public async Task<Guid> JoinChat(Guid friendId)
    {
        var userId = GetUserId();
        var chats = await _chatProvider.Get();
        var chat = chats.FirstOrDefault(c => c.UserIds.Contains(userId) && c.UserIds.Contains(friendId));

        if (chat == null)
        {
            chat = new ChatModel
            {
                Id = Guid.NewGuid(),
                IsGroup = false,
                UserIds = [userId, friendId]
            };

            await _chatManager.Create(chat);
        }

        var friend = ConnectedUsers.FirstOrDefault(x => x.Key == friendId);
        await Groups.AddToGroupAsync(Context.ConnectionId, chat.Id.ToString());
        await Groups.AddToGroupAsync(friend.Value, chat.Id.ToString());

        return chat.Id;
    }

    public async Task SendMessage(string chatId, string messageText)
    {
        var userId = GetUserId();
        var chat = await _chatProvider.GetOneById(Guid.Parse(chatId));
        if (chat == null)
        {
            throw new HubException("Chat not found.");
        }

        var message = new MessageModel
        {
            Id = Guid.NewGuid(),
            ChatId = chat.Id,
            UserId = userId,
            Text = messageText,
            SentTime = DateTime.UtcNow
        };

        await Clients.Group(chat.Id.ToString()).SendAsync("ReceiveMessage", message);

        await _messageManager.Create(message);
    }
}