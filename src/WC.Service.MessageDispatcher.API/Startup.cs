using Autofac;
using FluentValidation;
using WC.Service.MessageDispatcher.API.Hubs;
using WC.Service.MessageDispatcher.Domain;
using StartupBase = WC.Library.Web.Startup.StartupBase;

namespace WC.Service.MessageDispatcher.API;

internal sealed class Startup : StartupBase
{
    public Startup(WebApplicationBuilder builder) : base(builder)
    {
    }

    public override void ConfigureContainer(ContainerBuilder builder)
    {
        base.ConfigureContainer(builder);
        builder.RegisterModule<MessageDispatcherDomainModule>();

        builder.RegisterAssemblyTypes(typeof(Program).Assembly)
            .AsClosedTypesOf(typeof(IValidator<>))
            .AsImplementedInterfaces();
    }
    
    public override void ConfigureServices(WebApplicationBuilder builder)
    {
        base.ConfigureServices(builder);
        builder.Services.AddSignalR();
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigins",
                policyBuilder =>
                {
                    policyBuilder.WithOrigins("http://localhost:63342") // Укажите здесь URL вашего клиентского приложения
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials(); // Разрешите использование учетных данных
                });
        });
    }

    public override void Configure(WebApplication app)
    {
        base.Configure(app);
        app.UseCors("AllowSpecificOrigins"); // Используйте здесь имя вашей политики CORS
        app.MapHub<MessageDispatcherHub>("/chat");
    }
}