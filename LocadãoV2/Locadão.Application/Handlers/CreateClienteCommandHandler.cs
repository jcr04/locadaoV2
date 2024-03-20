using Locadao.Application.Interfaces.Commands;
using locadao.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locadão.Infra.Repository.Clientes;

namespace Locadão.Application.Handlers;

public class CreateClienteCommandHandler : ICommandHandler<CreateClienteCommand>
{
    private readonly IClienteRepository _clienteRepository;

    public CreateClienteCommandHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task HandleAsync(CreateClienteCommand command)
    {
        var cliente = new Cliente
        {
            Nome = command.Nome,
            Idade = command.Idade,
            Email = command.Email,
            Telefone = command.Telefone,
            Cpf = command.Cpf,
            TemCNH = command.TemCNH,
            IsPCD = command.IsPCD
        };

        await _clienteRepository.AddAsync(cliente);
    }
}
