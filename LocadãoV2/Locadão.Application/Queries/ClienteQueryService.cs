using Locadao.Application.Interfaces.Queries;
using locadao.Domain.Models;
using Locadão.Infra.Repository.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadão.Application.Queries;

public class ClienteQueryService : IClienteQueryService
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteQueryService(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Cliente> GetClienteByIdAsync(Guid id)
    {
        return await _clienteRepository.GetByIdAsync(id);
    }
}
