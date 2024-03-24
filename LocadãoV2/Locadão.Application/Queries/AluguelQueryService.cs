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

    public async Task<AluguelDTO> GetAluguelByIdAsync(Guid id)
    {
        var aluguel = await _aluguelRepository.GetAluguelByIdAsync(id);
        if (aluguel == null)
        {
            return null;
        }

        return new AluguelDTO
        {
            Id = aluguel.Id,
            DataInicio = aluguel.DataInicio,
            DataFim = aluguel.DataFim,
            Valor = aluguel.Valor,
            Status = aluguel.Status
            // Adicione outras propriedades conforme necessário
        };
    }
}

