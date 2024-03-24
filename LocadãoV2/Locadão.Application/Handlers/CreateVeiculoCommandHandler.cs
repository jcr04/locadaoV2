using Locadao.Application.Commands.Veiculos;
using Locadao.Application.Interfaces.Commands;
using locadao.Domain.Models;
using Locadão.Infra.Repository.Veiculos;
using System.Threading.Tasks;
using Locadão.Infra.Repository.Agencias;

namespace Locadão.Application.Handlers
{
    public class CreateVeiculoCommandHandler : ICommandHandler<CreateVeiculoCommand>
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IAgenciaRepository _agenciaRepository;

        public CreateVeiculoCommandHandler(IVeiculoRepository veiculoRepository, IAgenciaRepository agenciaRepository)
        {
            _veiculoRepository = veiculoRepository;
            _agenciaRepository = agenciaRepository;
        }

        public async Task<Guid> HandleAsync(CreateVeiculoCommand command)
        {
            var agencia = await _agenciaRepository.GetAgenciaByIdAsync(command.AgenciaId);
            if (agencia == null)
            {
                throw new Exception("Agência não encontrada.");
            }

            var existingVeiculo = await _veiculoRepository.GetByPlacaAsync(command.Placa);
            if (existingVeiculo != null)
            {
                throw new Exception("Veículo com esta placa já existe.");
            }

            if (await _veiculoRepository.PlacaExistsAsync(command.Placa))
            {
                throw new Exception("Um veículo com esta placa já está registrado.");
            }

            var veiculo = new Veiculo
            {
                Marca = command.Marca,
                Modelo = command.Modelo,
                AnoFabricacao = command.AnoFabricacao,
                Placa = command.Placa,
                Cor = command.Cor,
                Quilometragem = command.Quilometragem,
                Automatico = command.Automatico,
                DisponivelParaAluguel = command.DisponivelParaAluguel,
                AgenciaId = command.AgenciaId
            };

            await _veiculoRepository.AddAsync(veiculo);
            return veiculo.Id;
        }
    }
}
