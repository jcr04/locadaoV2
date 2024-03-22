using Locadao.Application.Interfaces.Queries;
using locadao.Domain.Models;
using Locadão.Infra.Repository.Alugueis;
using System;
using System.Threading.Tasks;
using Locadão.Application.Queries;

namespace Locadao.Application.Queries;

public class AluguelQueryService : IAluguelQueryService
{
    private readonly IAluguelRepository _aluguelRepository;

    public AluguelQueryService(IAluguelRepository aluguelRepository)
    {
        _aluguelRepository = aluguelRepository;
    }

    public async Task<Aluguel> GetAluguelByIdAsync(Guid id)
    {
        return await _aluguelRepository.GetAluguelByIdAsync(id);
    }
}
