using Autofac;
using FluentValidation;
using WC.Library.Domain.Services;
using WC.Service.MessageDispatcher.Data.PostgreSql;

namespace WC.Service.MessageDispatcher.Domain;

public class MessageDispatcherDomainModule : Module
{
    protected override void Load(
        ContainerBuilder builder)
    {
        builder.RegisterModule<MessageDispatcherDataPostgreSqlModule>();

        builder.RegisterAssemblyTypes(ThisAssembly)
            .AsClosedTypesOf(typeof(IDataProvider<>))
            .AsImplementedInterfaces();

        builder.RegisterAssemblyTypes(ThisAssembly)
            .AsClosedTypesOf(typeof(IDataManager<>))
            .AsImplementedInterfaces();

        builder.RegisterAssemblyTypes(ThisAssembly)
            .AsClosedTypesOf(typeof(IValidator<>))
            .AsImplementedInterfaces();
    }
}