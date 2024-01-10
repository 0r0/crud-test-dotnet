using Autofac;
using Mc2.CrudTest.Presentation.Shared;
using Mc2.DBProjection.Handlers;
using Neo4j.Driver;

namespace Mc2.DBProjection;

public class ProjectionModule : Module
{
    private readonly ApplicationSettings _applicationSettings;

    public ProjectionModule(ApplicationSettings applicationSettings)
    {
        _applicationSettings = applicationSettings;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(typeof(CustomerEventHandlers).Assembly).As(type => type.GetInterfaces()
            .Where(a => a.IsClosedTypeOf(typeof(IEventHandler<>)))).InstancePerLifetimeScope();
        builder.Register(GetNeo4J);
        base.Load(builder);
    }


    private IDriver GetNeo4J(IComponentContext context)
    {
        return GraphDatabase.Driver(_applicationSettings.Neo4jConnection,
            AuthTokens.Basic(_applicationSettings.Neo4jUser, _applicationSettings.Neo4jPassword));
    }
}