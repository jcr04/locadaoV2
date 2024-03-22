using Locadao.Application.Commands.Veiculos;
using Locadao.Application.Interfaces.Commands;
using locadao.Domain.Models;
using Locadão.Infra.Repository.Veiculos;
using System.Threading.Tasks;

namespace Locadão.Application.Handlers
{
    public class CreateVeiculoCommandHandler : ICommandHandler<CreateVeiculoCommand>
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public CreateVeiculoCommandHandler(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<Guid> HandleAsync(CreateVeiculoCommand command)
        {
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
                AgenciaId = command.AgenciaId,
            };

            var createdVeiculo = await _veiculoRepository.AddAsync(veiculo);
            return createdVeiculo.Id;
        }
    }
}
