using locadao.Domain.Models;

namespace Locadão.Infra.Repository.Agencias;

public interface IAgenciaRepository
{
    Task<Agencia> GetAgenciaByIdAsync(Guid id);

    Task<Agencia> AddAsync(Agencia agencia);

    Task DeleteAsync(Guid id);
    Task<int> CountVeiculosByAgenciaAsync(Guid agenciaId);
    Task<List<Aluguel>> GetAlugueisByAgenciaAsync(Guid agenciaId);
}
