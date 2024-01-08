using Autofac;
using Mc2.Application.CustomerManagers;
using Mc2.Application.CustomerManagers.Validators;
using Mc2.CrudTest.Presentation.Shared;
using Mc2.Query.CustomerManagers;

namespace Mc2.CrudTest.Presentation.Server.Module;

public class CustomerModule : Autofac.Module
{
    public CustomerModule()
    {
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CommandBus>().As<ICommandBus>().InstancePerLifetimeScope();
        builder.RegisterType<QueryBus>().As<IQueryBus>().InstancePerLifetimeScope();
        builder.RegisterAssemblyTypes(typeof(CustomerCommandHandlers).Assembly)
            .As(type => type.GetInterfaces().Where(t => t.IsClosedTypeOf(typeof(ICommandHandler<>))))
            .InstancePerLifetimeScope();
        builder.RegisterAssemblyTypes(typeof(CustomerQueryHandlers).Assembly)
            .As(type => type.GetInterfaces().Where(t => t.IsClosedTypeOf(typeof(IQueryHandler<,>))))
            .InstancePerLifetimeScope();
        builder.RegisterAssemblyTypes(typeof(DefineCustomerCommandValidator).Assembly)
            .AsClosedTypesOf(typeof(ICommandValidator<>))
            .AsImplementedInterfaces()
            .SingleInstance();
        
    }
}