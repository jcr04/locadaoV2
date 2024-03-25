using Locadao.Application.Commands;
using Locadao.Application.Commands.Veiculos;
using Locadao.Application.Interfaces.Commands;
using Locadão.Infra.Repository.Veiculos;

namespace Locadão.Application.Handlers;

public class UpdateVeiculoCommandHandler : ICommandHandler<UpdateVeiculoCommand>
{
    private readonly IVeiculoRepository _veiculoRepository;

    public UpdateVeiculoCommandHandler(IVeiculoRepository veiculoRepository)
    {
        _veiculoRepository = veiculoRepository;
    }

    public async Task<Guid> HandleAsync(UpdateVeiculoCommand command)
    {
        var veiculo = await _veiculoRepository.GetByIdAsync(command.Id);
        if (veiculo == null)
        {
            veiculo.Marca = command.Marca;
            veiculo.Modelo = command.Modelo;
            veiculo.AnoFabricacao = command.AnoFabricacao;
            veiculo.Placa = command.Placa;
            veiculo.Cor = command.Cor;

            await _veiculoRepository.UpdateAsync(veiculo);
        }
        else
        {
            throw new KeyNotFoundException("Veiculo não encontrado.");
        }

        return command.Id;
    }
}
