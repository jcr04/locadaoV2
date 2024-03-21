using Microsoft.AspNetCore.Mvc;
using Locadao.Application.Interfaces.Commands;
using System.Net;
using Locadao.Application.Interfaces.Queries;
using Locadão.Application.Queries;

namespace Locadão.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientesController : ControllerBase
{
    private readonly ICommandHandler<CreateClienteCommand> _createClienteHandler;
    private readonly IClienteQueryService _clienteQueryService;
    private readonly ICommandHandler<UpdateClienteCommand> _updateClienteHandler;
    private readonly ICommandHandlerDelete<DeleteClienteCommand> _deleteClienteHandler;

    public ClientesController(
        ICommandHandler<CreateClienteCommand> createClienteHandler,
        IClienteQueryService clienteQueryService,
        ICommandHandler<UpdateClienteCommand> updateClienteHandler,
        ICommandHandlerDelete<DeleteClienteCommand> deleteClienteHandler)
    {
        _createClienteHandler = createClienteHandler;
        _clienteQueryService = clienteQueryService;
        _updateClienteHandler = updateClienteHandler;
        _deleteClienteHandler = deleteClienteHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateClienteCommand command)
    {
        var createdClienteId = await _createClienteHandler.HandleAsync(command);
        var cliente = await _clienteQueryService.GetClienteByIdAsync(createdClienteId);

        return Ok(cliente);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var cliente = await _clienteQueryService.GetClienteByIdAsync(id);
        if (cliente != null)
        {
            return Ok(cliente);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateClienteCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("ID do cliente na URL é diferente do corpo da requisição.");
        }

        await _updateClienteHandler.HandleAsync(command);

        var clienteAtualizado = await _clienteQueryService.GetClienteByIdAsync(id);
        return Ok(clienteAtualizado);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _deleteClienteHandler.HandleAsync(new DeleteClienteCommand { Id = id });
        return NoContent();
    }
}
