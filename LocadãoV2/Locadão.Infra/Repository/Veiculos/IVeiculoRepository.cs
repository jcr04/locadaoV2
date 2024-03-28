using locadao.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadão.Infra.Repository.Veiculos
{
    public interface IVeiculoRepository
    {
        Task<IEnumerable<Veiculo>> GetAllAsync();
        Task<Veiculo> GetByIdAsync(Guid id);
        Task<Veiculo> AddAsync(Veiculo veiculo);
        Task UpdateAsync(Veiculo veiculo);
        Task DeleteAsync(Guid id);
        Task<Veiculo> GetByPlacaAsync(string placa);
        Task<bool> PlacaExistsAsync(string placa);
        Task<Veiculo> GetVeiculoAdaptadoDisponivelAsync(Guid agenciaId);
    }
}
