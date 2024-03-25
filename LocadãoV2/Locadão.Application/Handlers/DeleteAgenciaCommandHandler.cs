using Locadao.Application.Commands.Agencias;
using Locadao.Application.Interfaces.Commands;
using Locadão.Infra.Repository.Agencias;
using System.Threading.Tasks;

namespace Locadão.Application.Handlers;

public class DeleteAgenciaCommandHandler : ICommandHandlerDelete<DeleteAgenciaCommand>
{
    private readonly IAgenciaRepository _agenciaRepository;

    public DeleteAgenciaCommandHandler(IAgenciaRepository agenciaRepository)
    {
        _agenciaRepository = agenciaRepository;
    }

    public async Task HandleAsync(DeleteAgenciaCommand command)
    {
        await _agenciaRepository.DeleteAsync(command.Id);
    }
}
