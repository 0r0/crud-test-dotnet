namespace Mc2.CrudTest.Presentation.Shared;

public interface IQueryHandler<in TQuery,TResult> where TQuery:IQuery<TResult>
{
    Task<TResult> Handle(TQuery query);
}