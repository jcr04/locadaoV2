using Locadão.Application.Commands;
using Locadão.Infra.Repository.Alugueis;
using Locadao.Application.Interfaces.Commands;
using Locadão.Infra.Repository.Agencias;
using Locadão.Infra.Repository.Veiculos;
using locadao.Domain.Models;
using Locadão.Infra.Repository.Clientes;

namespace Locadão.Application.Handlers;

public class CreateAluguelCommandHandler : ICommandHandler<CreateAluguelCommand>
{
    private readonly IAluguelRepository _aluguelRepository;
    private readonly IVeiculoRepository _veiculoRepository;
    private readonly IAgenciaRepository _agenciaRepository;
    private readonly IClienteRepository _clienteRepository;

    public CreateAluguelCommandHandler(
        IAluguelRepository aluguelRepository,
        IVeiculoRepository veiculoRepository,
        IAgenciaRepository agenciaRepository,
        IClienteRepository clienteRepository)
    {
        _aluguelRepository = aluguelRepository;
        _veiculoRepository = veiculoRepository;
        _agenciaRepository = agenciaRepository;
        _clienteRepository = clienteRepository;
    }

    public async Task<Guid> HandleAsync(CreateAluguelCommand command)
    {
        // Verifica se o veículo existe e está associado à agência.
        var veiculo = await _veiculoRepository.GetByIdAsync(command.VeiculoId);
        if (veiculo == null || veiculo.AgenciaId != command.AgenciaId)
        {
            throw new Exception("Veículo não encontrado ou não pertence à agência.");
        }

        var cliente = await _clienteRepository.GetByIdAsync(command.ClienteId);
        if (cliente == null)
        {
            throw new Exception("Cliente não encontrado.");
        }

        if (cliente.IsPCD)
        {
            veiculo = await _veiculoRepository.GetVeiculoAdaptadoDisponivelAsync(command.AgenciaId);
            if (veiculo == null)
            {
                throw new Exception("Nenhum veículo adaptado disponível para aluguel.");
            }
        }
        else
        {
            veiculo = await _veiculoRepository.GetByIdAsync(command.VeiculoId);
            if (veiculo == null || veiculo.AgenciaId != command.AgenciaId)
            {
                throw new Exception("Veículo não encontrado ou não pertence à agência.");
            }
        }


        // Verifica se o veículo não está atualmente alugado.
        var isAlugado = await _aluguelRepository.IsVeiculoAlugadoAsync(command.VeiculoId);
        if (isAlugado)
        {
            throw new Exception("O veículo já está alugado.");
        }

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
