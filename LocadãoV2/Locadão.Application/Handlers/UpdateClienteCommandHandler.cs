using Locadao.Application.Interfaces.Commands;
using Locadão.Infra.Repository.Clientes;
using System;
using System.Threading.Tasks;

namespace Locadão.Application.Handlers;

public class UpdateClienteCommandHandler : ICommandHandler<UpdateClienteCommand>
{
    private readonly IClienteRepository _clienteRepository;

    public UpdateClienteCommandHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Guid> HandleAsync(UpdateClienteCommand command)
    {
        var cliente = await _clienteRepository.GetByIdAsync(command.Id);

        if (cliente != null)
        {
            cliente.Nome = command.Nome;
            cliente.Idade = command.Idade;
            cliente.Email = command.Email;
            cliente.Telefone = command.Telefone;

            await _clienteRepository.UpdateAsync(cliente);
        }
        else
        {
            throw new KeyNotFoundException("Cliente não encontrado.");
        }

        return command.Id;
    }
}
