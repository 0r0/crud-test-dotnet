using Autofac;

namespace Mc2.CrudTest.Presentation.Shared;

public class QueryBus : IQueryBus
{
    private readonly ILifetimeScope _lifetimeScope;

     public QueryBus(ILifetimeScope lifetimeScope)
    {
        _lifetimeScope = lifetimeScope;
    }

    public Task<TResult> Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
    {
        var handler = _lifetimeScope.Resolve<IQueryHandler<TQuery, TResult>>();
        return handler.Handle(query);
    }
}