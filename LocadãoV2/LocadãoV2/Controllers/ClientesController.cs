using Microsoft.AspNetCore.Mvc;
using Locadao.Application.Interfaces.Commands;
using System.Net;

namespace Locadão.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientesController : ControllerBase
{
    private readonly ICommandHandler<CreateClienteCommand> _createClienteHandler;
    private readonly ICommandHandler<UpdateClienteCommand> _updateClienteHandler;
    private readonly ICommandHandler<DeleteClienteCommand> _deleteClienteHandler;

    public ClientesController(
        ICommandHandler<CreateClienteCommand> createClienteHandler,
        ICommandHandler<UpdateClienteCommand> updateClienteHandler,
        ICommandHandler<DeleteClienteCommand> deleteClienteHandler)
    {
        _createClienteHandler = createClienteHandler;
        _updateClienteHandler = updateClienteHandler;
        _deleteClienteHandler = deleteClienteHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateClienteCommand command)
    {
        await _createClienteHandler.HandleAsync(command);
        return StatusCode(201);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateClienteCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("ID do cliente na URL é diferente do corpo da requisição.");
        }

        await _updateClienteHandler.HandleAsync(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _deleteClienteHandler.HandleAsync(new DeleteClienteCommand { Id = id });
        return NoContent();
    }
}
