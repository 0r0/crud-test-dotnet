using Arius.Config.Autofac;
using Autofac;
using DDDFramework.Core;
using Mc2.Application;
using Mc2.Application.CustomerManagers;
using Mc2.Application.CustomerManagers.Validators;
using Mc2.CrudTest.Presentation.Server.Handlers;
using Mc2.CrudTest.Presentation.Shared;
using Mc2.CrudTest.Presentation.Shared.AggregateRootFactory;
using Mc2.CrudTest.Presentation.Shared.EventStore;
using Mc2.DBProjection.Handlers;
using Mc2.Query;
using Mc2.Query.CustomerManagers;
using Neo4j.Driver;
using Neo4jClient;

namespace Mc2.CrudTest.Presentation.Server.Module;

public class CustomerModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(EventSourceRepository<,>)).As(typeof(IEventSourceRepository<,>))
            .SingleInstance();
        builder.RegisterAssemblyTypes(typeof(CustomerRepository).Assembly)
            .Where(a => typeof(IRepository).IsAssignableFrom(a))
            .AsImplementedInterfaces().InstancePerLifetimeScope();
        builder.RegisterAssemblyTypes(typeof(CustomerService).Assembly)
            .Where(a => typeof(IDomainService).IsAssignableFrom(a))
            .AsImplementedInterfaces().InstancePerLifetimeScope();
        builder.RegisterType<EventBus>().As<IEventBus>();

        builder.RegisterType<CommandBus>().As<ICommandBus>().InstancePerLifetimeScope();
        builder.RegisterType<EventPublisher>().As<IEventPublisher>().InstancePerLifetimeScope();
        builder.RegisterType<QueryBus>().As<IQueryBus>().InstancePerLifetimeScope();
        builder.RegisterType<InMemoryEventStore>().As<IEventStore>().InstancePerLifetimeScope();
        builder.RegisterAssemblyTypes(typeof(CustomerCommandHandlers).Assembly)
            .As(type => type.GetInterfaces().Where(t => t.IsClosedTypeOf(typeof(ICommandHandler<>))))
            .InstancePerLifetimeScope();
        builder.RegisterAssemblyTypes(typeof(CustomerEventHandlers).Assembly).As(type => type.GetInterfaces()
            .Where(a => a.IsClosedTypeOf(typeof(IEventHandler<>)))).SingleInstance();
        builder.RegisterAssemblyTypes(typeof(CustomerQueryHandlers).Assembly)
            .As(type => type.GetInterfaces().Where(t => t.IsClosedTypeOf(typeof(IQueryHandler<,>))))
            .InstancePerLifetimeScope();
        builder.RegisterAssemblyTypes(typeof(DefineCustomerCommandValidator).Assembly)
            .AsClosedTypesOf(typeof(ICommandValidator<>))
            .AsImplementedInterfaces()
            .SingleInstance();
        builder.RegisterType<AggregateRootFactory>().As<IAggregateRootFactory>().SingleInstance();

        builder.RegisterType<AutofacQueryHandlerFactory>().As<IQueryHandlerFactory>();
        builder.RegisterType<EventAggregator>().As<IEventAggregator>().InstancePerLifetimeScope();
        builder.RegisterType<CustomerArgsFactory>().As<ICustomerArgsFactory>().InstancePerLifetimeScope();
        builder.RegisterType<ServiceRegistryLifetimeScope>().As<IServiceRegistryLifetimeScope>()
            .InstancePerLifetimeScope();
        builder.RegisterGeneric(typeof(GenericEventHandlers<>)).As(typeof(IGenericEventHandlers<>)).SingleInstance();
        builder.Register(GetNeo4J);
        builder.Register(GetGraphClient);

        base.Load(builder);
    }

    private IDriver GetNeo4J(IComponentContext context)
    {
        return GraphDatabase.Driver("bolt://localhost:7687",
            AuthTokens.Basic("neo4j", "Mehdi"));
    }

    private GraphClient GetGraphClient(IComponentContext context)
    {

        var client = new GraphClient(new Uri("http://neo4j:Mehdi@localhost:7474"))
        {
            DefaultDatabase = "neo4j"
        };
        return client;
    }
}