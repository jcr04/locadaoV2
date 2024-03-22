using locadao.Domain.Models;
using Locadão.Infra.Repository.Veiculos;


namespace Locadão.Application.Queries;

public class VeiculoQueryService : IVeiculoQueryService
{
    private readonly IVeiculoRepository _veiculoRepository;

    public VeiculoQueryService(IVeiculoRepository veiculoRepository)
    {
        _veiculoRepository = veiculoRepository;
    }

    public async Task<Veiculo> GetVeiculoByIdAsync(Guid id)
    {
        return await _veiculoRepository.GetByIdAsync(id);
    }
}
