using AutoMapper;
using WC.Service.MessageDispatcher.Data.Models;
using WC.Service.MessageDispatcher.Domain.Models;

namespace WC.Service.MessageDispatcher.Domain;

public sealed class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<MessageModel, MessageEntity>().ReverseMap();
        CreateMap<ChatModel, ChatEntity>().ReverseMap();
    }
}