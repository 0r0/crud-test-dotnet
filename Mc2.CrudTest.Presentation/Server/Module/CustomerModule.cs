using Autofac;
using Mc2.CrudTest.Presentation.Shared;

namespace Mc2.CrudTest.Presentation.Module;

public class CustomerModule : Autofac.Module
{
    public CustomerModule()
    {
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CommandBus>().As<ICommandBus>().InstancePerLifetimeScope();
        builder.RegisterType<QueryBus>().As<IQueryBus>().InstancePerLifetimeScope();
        
    }
}