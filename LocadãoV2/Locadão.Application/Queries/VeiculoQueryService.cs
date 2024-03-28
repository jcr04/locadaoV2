
using Locadão.Infra.Repository.Veiculos;

using Locadão.Domain.models.DTOs;

namespace Locadão.Application.Queries
{
    public class VeiculoQueryService : IVeiculoQueryService
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoQueryService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<VeiculoDTO> GetVeiculoByIdAsync(Guid id)
        {
            var veiculo = await _veiculoRepository.GetByIdAsync(id);
            if (veiculo == null) return null;

            return new VeiculoDTO
            {
                Id = veiculo.Id,
                Marca = veiculo.Marca,
                Modelo = veiculo.Modelo,
                AnoFabricacao = veiculo.AnoFabricacao,
                Placa = veiculo.Placa,
                Cor = veiculo.Cor,
                AdaptadoParaPCD = veiculo.AdaptadoParaPCD
                // Mapeie outras propriedades conforme necessário
            };
        }
    }
}
