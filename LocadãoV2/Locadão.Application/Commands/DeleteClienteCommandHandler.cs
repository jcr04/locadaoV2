using Locadao.Application.Interfaces.Commands;
using Locadão.Infra.Repository.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadão.Application.Commands;

public class DeleteClienteCommandHandler : ICommandHandler<DeleteClienteCommand>
{
    private readonly IClienteRepository _clienteRepository;

    public DeleteClienteCommandHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task HandleAsync(DeleteClienteCommand command)
    {
        await _clienteRepository.DeleteAsync(command.Id);
    }
}
