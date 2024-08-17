using Microsoft.AspNetCore.Mvc;
using Locadão.Application.Commands;
using Locadao.Application.Interfaces.Commands;
using Locadão.Application.Queries;

namespace Locadão.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlugueisController : ControllerBase
{
    private readonly ICommandHandler<CreateAluguelCommand> _createAluguelHandler;
    private readonly ICommandHandlerDelete<DeleteAluguelCommand> _deleteAluguelHandler;
    private readonly IAluguelQueryService _aluguelQueryService;

    public AlugueisController(
        ICommandHandler<CreateAluguelCommand> createAluguelHandler,
        ICommandHandlerDelete<DeleteAluguelCommand> deleteAluguelHandler,
        IAluguelQueryService aluguelQueryService)
    {
        _createAluguelHandler = createAluguelHandler;
        _deleteAluguelHandler = deleteAluguelHandler;
        _aluguelQueryService = aluguelQueryService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAluguelCommand command)
    {
        var aluguelId = await _createAluguelHandler.HandleAsync(command);
        var aluguelDto = await _aluguelQueryService.GetAluguelByIdAsync(aluguelId);
        return CreatedAtAction(nameof(GetById), new { id = aluguelId }, aluguelDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteAluguelCommand { Id = id };
        await _deleteAluguelHandler.HandleAsync(command);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var aluguelDto = await _aluguelQueryService.GetAluguelByIdAsync(id);
        if (aluguelDto == null)
        {
            return NotFound();
        }

        return Ok(aluguelDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAlugueisDisponiveis()
    {
        var alugueis = await _aluguelQueryService.GetAlugueisDisponiveisAsync();
        return Ok(alugueis);
    }
}
