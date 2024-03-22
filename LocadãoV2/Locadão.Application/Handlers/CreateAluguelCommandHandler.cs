using Locadão.Application.Commands;
using Locadão.Infra.Repository.Alugueis;
using Locadao.Application.Interfaces.Commands;

namespace Locadão.Application.Handlers;

public class CreateAluguelCommandHandler : ICommandHandler<CreateAluguelCommand>
{
    private readonly IAluguelRepository _aluguelRepository;

    public CreateAluguelCommandHandler(IAluguelRepository aluguelRepository)
    {
        _aluguelRepository = aluguelRepository;
    }

    public async Task<Guid> HandleAsync(CreateAluguelCommand command)
    {
        var aluguel = new Aluguel
        {
            ClienteId = command.ClienteId,
            VeiculoId = command.VeiculoId,
            AgenciaId = command.AgenciaId,
            DataInicio = command.DataInicio,
            DataFim = command.DataFim,
            Valor = command.Valor,
            Status = command.Status
        };

        var createdAluguel = await _aluguelRepository.AddAsync(aluguel);
        return createdAluguel.Id;
    }
}
