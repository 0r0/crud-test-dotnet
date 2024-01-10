using Autofac;
using Mc2.CrudTest.Presentation.Shared;
using Mc2.DBProjection.Handlers;

namespace Mc2.DBProjection;

public class ProjectionModule :Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(typeof(CustomerEventHandlers).Assembly).As(type => type.GetInterfaces()
            .Where(a => a.IsClosedTypeOf(typeof(IEventHandler<>)))).InstancePerLifetimeScope();
        base.Load(builder);
    }
}