using Autofac;
using FluentValidation;
using WC.Service.MessageDispatcher.Domain;
using StartupBase = WC.Library.Web.Startup.StartupBase;

namespace WC.Service.MessageDispatcher.API;

internal sealed class Startup : StartupBase
{
    public Startup(WebApplicationBuilder builder) : base(builder)
    {
    }

    public override void ConfigureContainer(
        ContainerBuilder builder)
    {
        base.ConfigureContainer(builder);
        builder.RegisterModule<MessageDispatcherDomainModule>();
        
        builder.RegisterAssemblyTypes(typeof(Program).Assembly)
            .AsClosedTypesOf(typeof(IValidator<>))
            .AsImplementedInterfaces();
    }
}