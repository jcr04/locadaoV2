using Locadão.Domain.models.DTOs;
using Locadão.Infra.Repository.Alugueis;

namespace Locadão.Application.Queries;

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
            Status = aluguel.Status,
            Agencia = aluguel.Agencia.Nome,
            Veiculo = new VeiculoDTO
            {
                Id = aluguel.Veiculo.Id,
                Marca = aluguel.Veiculo.Marca,
                Modelo = aluguel.Veiculo.Modelo,
                Placa = aluguel.Veiculo.Placa,
            },
        };
    }
    public async Task<List<AluguelDTO>> GetAlugueisDisponiveisAsync()
    {
        var alugueis = await _aluguelRepository.GetAlugueisDisponiveisAsync();
        return alugueis.Select(aluguel => new AluguelDTO
        {
            Id = aluguel.Id,
            DataInicio = aluguel.DataInicio,
            DataFim = aluguel.DataFim,
            Valor = aluguel.Valor,
            Status = aluguel.Status,
            Agencia = aluguel.Agencia.Nome,
            Veiculo = new VeiculoDTO
            {
                Id = aluguel.Veiculo.Id,
                Marca = aluguel.Veiculo.Marca,
                Modelo = aluguel.Veiculo.Modelo,
                Placa = aluguel.Veiculo.Placa,
            },
        }).ToList();
    }
}

