namespace Mc2.CrudTest.Presentation.Shared;

public interface IQueryBus
{
    Task<TResult> Execute<TQuery,TResult>(TQuery query) where TQuery : IQuery<TResult>;
}