using Autofac;
using Microsoft.EntityFrameworkCore;
using WC.Library.Data.Repository;
using WC.Service.MessageDispatcher.Data.PostgreSql.Context;

namespace WC.Service.MessageDispatcher.Data.PostgreSql;

public class MessageDispatcherDataPostgreSqlModule : Module
{
    protected override void Load(
        ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(ThisAssembly)
            .AsClosedTypesOf(typeof(IRepository<>))
            .AsImplementedInterfaces();

        builder.RegisterType<MessageDispatcherDbContextFactory>()
            .AsSelf()
            .SingleInstance();

        builder.Register(c => c.Resolve<MessageDispatcherDbContextFactory>().CreateDbContext())
            .As<MessageDispatcherDbContext>()
            .As<DbContext>()
            .InstancePerLifetimeScope();
    }
}