namespace Locadao.Application.Interfaces.Queries;

public interface IQuery<TResult>
{
    Task<TResult> ExecuteAsync();
}