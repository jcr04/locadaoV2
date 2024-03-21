namespace Locadao.Application.Interfaces.Commands
{
    public interface ICommandHandlerDelete<TCommand>
    {
        Task HandleAsync(TCommand command);
    }
}
