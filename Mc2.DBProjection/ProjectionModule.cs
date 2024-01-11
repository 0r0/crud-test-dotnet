using Autofac;
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
        builder.Register(GetNeo4J);
        base.Load(builder);
    }


    private IDriver GetNeo4J(IComponentContext context)
    {
        return GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("neo4j", "Mehdi"));
    }
}