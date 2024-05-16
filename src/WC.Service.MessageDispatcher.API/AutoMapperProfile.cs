using AutoMapper;
using WC.Service.MessageDispatcher.API.Models.Chat;
using WC.Service.MessageDispatcher.API.Models.Message;
using WC.Service.MessageDispatcher.Domain.Models;

namespace WC.Service.MessageDispatcher.API;

public sealed class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<MessageModel, MessageDto>().ReverseMap();
        CreateMap<ChatModel, ChatDto>().ReverseMap();
    }
}