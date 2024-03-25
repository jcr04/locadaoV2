using Locadao.Application.Commands.Agencias;
using Locadao.Application.Interfaces.Commands;
using locadao.Domain.Models;
using Locadão.Infra.Repository.Agencias;
using System.Threading.Tasks;

namespace Locadão.Application.Handlers;

public class CreateAgenciaCommandHandler : ICommandHandler<CreateAgenciaCommand>
{
    private readonly IAgenciaRepository _agenciaRepository;

    public CreateAgenciaCommandHandler(IAgenciaRepository agenciaRepository)
    {
        _agenciaRepository = agenciaRepository;
    }

    public async Task<Guid> HandleAsync(CreateAgenciaCommand command)
    {
        var agencia = new Agencia
        {
            Nome = command.Nome,
            Endereco = command.Endereco,
            Telefone = command.Telefone,
        };

        await _agenciaRepository.AddAsync(agencia);
        return agencia.Id;
    }
}
