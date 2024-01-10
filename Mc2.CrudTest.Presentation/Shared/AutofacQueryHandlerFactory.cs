using Autofac;

namespace Mc2.CrudTest.Presentation.Shared;

public class AutofacQueryHandlerFactory : IQueryHandlerFactory
{
    private readonly ILifetimeScope _lifetimeScope;
    public AutofacQueryHandlerFactory(ILifetimeScope lifetimeScope)
    {
        _lifetimeScope = lifetimeScope;
    }
    public IQueryHandler<TQuery, TResult> CreateHandler<TQuery, TResult>() where TQuery : IQuery<TResult>
    {
        return _lifetimeScope.Resolve<IQueryHandler<TQuery, TResult>>();
    }
}