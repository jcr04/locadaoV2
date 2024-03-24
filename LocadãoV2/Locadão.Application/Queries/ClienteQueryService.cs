using Locadao.Application.Interfaces.Queries;
using locadao.Domain.Models;
using Locadão.Infra.Repository.Clientes;
using Locadão.Domain.models.DTOs;

namespace Locadão.Application.Queries;

public class ClienteQueryService : IClienteQueryService
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteQueryService(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<ClienteDTO> GetClienteByIdAsync(Guid id)
    {
        var cliente = await _clienteRepository.GetByIdAsync(id);
        if (cliente == null)
        {
            return null;
        }

        return new ClienteDTO
        {
            Id = cliente.Id,
            Nome = cliente.Nome,
            Idade = cliente.Idade,
            Email = cliente.Email,
            Telefone = cliente.Telefone
            // Mapeie outros campos conforme necessário
        };
    }
}
