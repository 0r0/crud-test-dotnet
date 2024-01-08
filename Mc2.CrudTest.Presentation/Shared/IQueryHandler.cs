namespace Mc2.CrudTest.Presentation.Shared;

public interface IQueryHandler<in TQuery,TResult> where TQuery:IQuery<TResult>
{
    TResult Handle(TQuery query);
}