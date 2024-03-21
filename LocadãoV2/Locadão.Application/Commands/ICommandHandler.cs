namespace Locadao.Application.Interfaces.Commands
{
    public interface ICommandHandler<TCommand>
    {
        Task<Guid> HandleAsync(TCommand command);
    }
}
