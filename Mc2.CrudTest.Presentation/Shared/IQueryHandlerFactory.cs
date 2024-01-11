namespace Mc2.CrudTest.Presentation.Shared
{
    public interface IQueryHandlerFactory
    {
        IQueryHandler<TQuery, TResult> CreateHandler<TQuery, TResult>() where TQuery : IQuery<TResult>;
    }
}
